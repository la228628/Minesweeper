using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesWheeper
{
    public abstract class Case
    {
        public bool EstRévélé;
        public bool EstMarqué;
        public int NombreBombesAdjacentes;
        public bool Interrogation;


        public int Ligne;
        public int Colonne;

        public bool EstAReveler;
        public Case(int ligne, int colonne) 
        { 
            this.EstRévélé = false;
            this.EstMarqué = false; 
            this.Colonne = colonne;
            this.Ligne = ligne;
            this.EstAReveler = false;
            this.Interrogation = false;
        }


        public abstract void Révéler(Jeu jeuCourant);
        public virtual void RevelerUneCase(Jeu jeuCourant) { }
        public abstract void Marquer(Jeu jeuCourant);

        public virtual bool ACasesProchesAReveler(Jeu jeuCourant) { return false; }
    }
}