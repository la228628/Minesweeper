using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace MinesWheeper
{
    public class Grille
    {
        public int Lignes;
        public int Colonnes;
        public int NombreDeMines;
        public Case[,] TableauDeCase;

        public Grille(int lignes, int colonnes, int mines) 
        {
            this.Lignes = lignes;
            this.Colonnes = colonnes;
            this.NombreDeMines = mines;

            this.TableauDeCase = new Case[this.Lignes,this.Colonnes];



        }
        

        public void RemplirLeTableau()
        {
            for(int i = 0; i < this.Lignes; i++)
            {
                for(int j=0; j < this.Colonnes; j++)
                {
                    this.TableauDeCase[i,j] = new CaseVide(i,j);
                }
            }
        }


        public void PlacerLesMines(EModes modeDeJeu) 
        {
            
            int nombreMinesPlacées = 0;
            Random aléatoire = new Random();

            while(nombreMinesPlacées < this.NombreDeMines) 
            {
                int ligneCourante = aléatoire.Next(0,this.Lignes);
                int colonneCourante = aléatoire.Next(0,this.Colonnes);

                if (this.TableauDeCase[ligneCourante,colonneCourante] is CaseVide)
                {
                    switch (modeDeJeu)
                    {
                        case EModes.Facile:
                            this.TableauDeCase[ligneCourante, colonneCourante] = new CaseMineFacile(ligneCourante,colonneCourante);
                            nombreMinesPlacées++;

                            break;
                        case EModes.Normal:
                            this.TableauDeCase[ligneCourante, colonneCourante] = new CaseMine(ligneCourante, colonneCourante);
                            nombreMinesPlacées++;
                            break;
                        case EModes.Spécial:
                            this.TableauDeCase[ligneCourante, colonneCourante] = new CaseMineSpeciale(ligneCourante, colonneCourante);
                            nombreMinesPlacées++;
                            break;
                    }
                    
                }

            }

        }
    }
}
