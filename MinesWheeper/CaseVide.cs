using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesWheeper
{
    public class CaseVide:Case
    {
        public CaseVide(int ligne,int colonne):base(ligne,colonne) { }
        public override void Révéler(Jeu jeuCourant)
        {

            if (jeuCourant.PremiereAction == true) //pour minimiser les chances de se retouver bloqué au premier clic
            {
                jeuCourant.Chronomètre.Start();
                jeuCourant.PremiereAction = false;
                jeuCourant.RemplacerCasesDepuis(this.Ligne, this.Colonne);
            }
            else if(this.EstRévélé==false && !jeuCourant.APerdu && !jeuCourant.AGagné())
            {
                this.RevelerUneCase(jeuCourant);
            }
            else if(this.EstRévélé==true && this.NombreBombesAdjacentes !=0)
            {
                jeuCourant.RevelerAutourDe(this.Ligne, this.Colonne);
            }


            while (jeuCourant.AucuneCaseAReveler() == false) //La fonction pour réveler toutes les cases adjacentes qui n'ont pas de mines autour
            {
                foreach (Case uneCase in jeuCourant.GrilleCourante.TableauDeCase)
                {
                    if (uneCase.EstAReveler == true)
                    {
                        uneCase.RevelerUneCase(jeuCourant);
                    }
                }
            }

            jeuCourant.VerifierVictoire();

        }


        public override void RevelerUneCase(Jeu jeuCourant)
        {
            if (!this.EstMarqué)
            {
                this.NombreBombesAdjacentes = 0;



                for (int ligne = this.Ligne - 1; ligne <= this.Ligne + 1; ligne++)
                {
                    for (int colonne = this.Colonne - 1; colonne <= this.Colonne + 1; colonne++)
                    {
                        if(jeuCourant.GrilleCourante.TableauDeCase.ContientLaCoordonée(ligne,colonne))
                        {
                            if (jeuCourant.RenvoyerCaseA(ligne,colonne) is CaseMine)
                            {
                                this.NombreBombesAdjacentes++;
                            }

                        }
                    }
                }




                this.EstRévélé = true;

                jeuCourant.VerifierVictoire();
            }
        }

        public override void Marquer(Jeu jeuCourant)
        {
            if (jeuCourant.PremiereAction == true)
            {
                jeuCourant.Chronomètre.Start();
                jeuCourant.PremiereAction = false;
            }
            if (!this.EstRévélé && !jeuCourant.APerdu && !jeuCourant.AGagné())
            {
                if (this.EstMarqué == false)
                {
                    this.EstMarqué = true;
                    jeuCourant.DrapeauxRestants--;
                }
                else if (this.EstMarqué == true)
                {
                    if (this.Interrogation == false)
                    {
                        this.Interrogation = true;
                    }
                    else
                    {
                        this.Interrogation = false;
                        this.EstMarqué = false;
                        jeuCourant.DrapeauxRestants++;
                    }

                }
            }
        }



        public override bool ACasesProchesAReveler(Jeu jeuCourant)
        {

            bool resutlat = false;


            if (this.EstRévélé == false)
            {
                resutlat = false;
            }
            else if (this.NombreBombesAdjacentes != 0)
            {
                resutlat = false;

            }
            else
            {

                for (int ligne = this.Ligne - 1; ligne <= this.Ligne + 1; ligne++)
                {
                    for (int colonne = this.Colonne - 1; colonne <= this.Colonne + 1; colonne++)
                    {
                        if (jeuCourant.GrilleCourante.TableauDeCase.ContientLaCoordonée(ligne, colonne))
                        {

                            if(jeuCourant.RenvoyerCaseA(ligne,colonne).EstRévélé ==false && jeuCourant.RenvoyerCaseA(ligne, colonne).EstMarqué == false)
                            {

                                jeuCourant.RenvoyerCaseA(ligne,colonne).EstAReveler = true;
                                resutlat = true;
                            }

                        }
                    }
                }

            }
               
            return resutlat;
        } //Cette fonction sert à détecter si il y a des cases adjacentes autour de "this" si "this" n'a acune mine autour. Les cases adjacentes seront indiquées comme "a réveler"

    }
}
