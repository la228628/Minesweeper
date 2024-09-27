using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MinesWheeper
{
    public class Jeu
    {
        public Grille GrilleCourante;
        
        public bool APerdu;
        public bool PremiereAction;
        public int ValeurDécompteur;
        public EModes ModeDeJeu;
        public EConfigGrille TailleGrille;

        public Stopwatch Chronomètre;

        public int NombreVieModeFacile;

        public Stopwatch CompteAReboursModeSpécial;


        public int BombesTrouvées;
        public int DrapeauxRestants;
        public Jeu(EModes mode = EModes.Normal, EConfigGrille taillegrille = EConfigGrille.Moyenne) 
        {
            this.APerdu = false;
            this.PremiereAction = true;
            this.ModeDeJeu = mode;
            this.TailleGrille = taillegrille;

            switch (TailleGrille)
            {
                case EConfigGrille.Petite:
                    this.GrilleCourante = new Grille(8,10,15);
                    this.ValeurDécompteur = 90;
                    break;
                case EConfigGrille.Moyenne:
                    this.GrilleCourante = new Grille(12,16,35);
                    this.ValeurDécompteur= 180;
                    break;
                case EConfigGrille.Grande:
                    this.GrilleCourante = new Grille(18, 24, 65);
                    this.ValeurDécompteur = 300;
                    break;

            }

            this.GrilleCourante.RemplirLeTableau();

            this.GrilleCourante.PlacerLesMines(ModeDeJeu);

            this.Chronomètre = new Stopwatch();

            this.NombreVieModeFacile = 3;

            this.CompteAReboursModeSpécial = new Stopwatch();

            this.BombesTrouvées = 0;
            this.DrapeauxRestants = this.GrilleCourante.NombreDeMines;

        }

        public bool AucuneCaseAReveler() //ce booléen renvoye true si aucune case n'est marquée comme "a réveler"      
        {
            bool resultat = true;
            foreach(Case uneCase in this.GrilleCourante.TableauDeCase)
            {
                if(uneCase is CaseVide && uneCase.ACasesProchesAReveler(this)==true) //(Voir dans CaseVide) Les cases "a réveler" seront indiquées grâce à l'appel de la fonction
                {
                    resultat = false;
                    break;
                }
            }
            return resultat;
        }



        public void RemplacerCasesDepuis(int ligne,int colonne)
        {

            int nombresMinesAReplacer = 0;


            List<(int, int)> coordonneesExclues = new List<(int, int)> ();


            for (int i = ligne-2; i<=ligne+2; i++)
            {

                for(int j = colonne-3; j <= colonne+3; j++)
                {
                    if (this.GrilleCourante.TableauDeCase.ContientLaCoordonée(i,j))
                    {
                        if (RenvoyerCaseA(i, j) is CaseMine)
                        {

                            this.GrilleCourante.TableauDeCase[i, j] = new CaseVide(i, j);

                            nombresMinesAReplacer++;
                        }
                    }
                    coordonneesExclues.Add((i, j));
                }
            }

            //foreach ((int, int) coordonee in coordonneesExclues)
            //{
            //    Debug.WriteLine(coordonee.ToString());
            //}

            for (int i = 0; i< nombresMinesAReplacer; i++) 
            {

                int ligneRemplacement;
                int colonneRemplacement;
                this.GrilleCourante.TableauDeCase[ligne, colonne] = new CaseVide(ligne, colonne);

                do
                {
                    ligneRemplacement = new Random().Next(0, this.GrilleCourante.Lignes);
                    colonneRemplacement = new Random().Next(0, this.GrilleCourante.Colonnes);
                } while (this.GrilleCourante.TableauDeCase[ligneRemplacement, colonneRemplacement] is not CaseVide || coordonneesExclues.Contains((ligneRemplacement, colonneRemplacement)));
                //Debug.WriteLine(ligneRemplacement + "" + colonneRemplacement);
                switch (this.ModeDeJeu)
                {
                    case EModes.Facile:
                        this.GrilleCourante.TableauDeCase[ligneRemplacement, colonneRemplacement] = new CaseMineFacile(ligneRemplacement, colonneRemplacement);
                        break;
                    case EModes.Normal:
                        this.GrilleCourante.TableauDeCase[ligneRemplacement, colonneRemplacement] = new CaseMine(ligneRemplacement, colonneRemplacement);
                        break;
                    case EModes.Spécial:
                        this.GrilleCourante.TableauDeCase[ligneRemplacement, colonneRemplacement] = new CaseMineSpeciale(ligneRemplacement, colonneRemplacement);
                        break;
                }

            }
            this.RenvoyerCaseA(ligne, colonne).Révéler(this);
        }



        public Case RenvoyerCaseA(int ligne, int colonne)
        {
            return this.GrilleCourante.TableauDeCase[ligne, colonne];
        }


        public void CommencerCompteARebours()
        {
            this.CompteAReboursModeSpécial.Start();

            Task.Run(VerifCompteARebours);  //Permet d'éxecuter une fonction continuellement sans arrêter le reste du code

        }




        public void RevelerAutourDe(int ligne, int colonne) //révélation automatique des cases autour d'une case déjà révélée si le nombre de drapeaux correspond au nombre de mines autour de cette case
        {
            int minesSuposéesAutour = 0;
            for (int i = ligne - 1; i <= ligne + 1; i++)
            {
                for (int j = colonne-1 ; j <= colonne + 1; j++)
                {
                    if (this.GrilleCourante.TableauDeCase.ContientLaCoordonée(i, j))
                    {
                        if(i== ligne && j == colonne)
                        {
                            continue;
                        }else
                        if ((this.RenvoyerCaseA(i, j).EstMarqué == true && this.RenvoyerCaseA(i,j).Interrogation==false )|| (this.RenvoyerCaseA(i,j) is CaseMine && this.RenvoyerCaseA(i,j).EstRévélé)     )
                        {
                            minesSuposéesAutour++;
                        }
                    }
                }
            }

            if (minesSuposéesAutour == this.RenvoyerCaseA(ligne, colonne).NombreBombesAdjacentes)
            {
                for (int i = ligne - 1; i <= ligne + 1; i++)
                {
                    for (int j = colonne-1; j <= colonne + 1; j++)
                    {
                        if (this.GrilleCourante.TableauDeCase.ContientLaCoordonée(i, j))
                        {
                            if (this.RenvoyerCaseA(i, j).EstMarqué ==false &&this.RenvoyerCaseA(i,j).EstRévélé==false)
                            {
                                this.RenvoyerCaseA(i, j).Révéler(this);
                            }
                        }
                    }
                }
            }


        }


        public bool AGagné()
        {
            bool résultat =false ;
            foreach(Case uneCase in this.GrilleCourante.TableauDeCase)
            {
                if (uneCase is CaseVide)
                {
                    if (uneCase.EstRévélé == true)
                    {
                        résultat = true;
                    }
                    else
                    {
                        résultat = false;
                        break;
                    }
                }
            }
            
            return résultat;
        }

        public string ConversionEnMinutes(long tempssecondes)
        {
            long minutes;
            string strminutes;
            long secondes;
            string résultat;
            string strsecondes;

            if (tempssecondes >= 60)
            {
                minutes = tempssecondes / 60;
                secondes = tempssecondes % 60;

                if(minutes < 10)
                {
                    strminutes = "0" + minutes.ToString();
                }
                else
                {
                    strminutes = minutes.ToString();
                }

                if(secondes < 10)
                {
                    strsecondes = "0"+secondes.ToString();
                }
                else
                {
                    strsecondes=secondes.ToString();
                }

                résultat = strminutes + ":" + strsecondes;
            }
            else
            {
                if (tempssecondes < 10)
                {
                    résultat = "00:" + "0" + tempssecondes.ToString();
                }
                else
                {
                    résultat = "00:"+ tempssecondes.ToString();
                }
            }
            if(tempssecondes <= 0)
            {
                résultat = "00:00";
            }
            

            return résultat;
        }

        private void VerifCompteARebours()
        {
            while (!this.APerdu)
            {
                if (this.CompteAReboursModeSpécial.ElapsedMilliseconds >= this.ValeurDécompteur * 1000)
                {
                    this.APerdu = true;
                    this.RevelerToutesLesMines();
                    this.CompteAReboursModeSpécial.Stop();
                    this.Chronomètre.Stop();
                }
            }
        }

        public void VerifierVictoire() 
        {
                if (this.AGagné() == true)
                {
                    this.Chronomètre.Stop();
                    this.CompteAReboursModeSpécial.Stop();
                }
        }

        public void RevelerToutesLesMines()
        {
            foreach (Case uneCase in this.GrilleCourante.TableauDeCase)
            {

                if (uneCase is CaseMine)
                {
                    uneCase.EstRévélé = true;
                }
            }
        }


    }
}
