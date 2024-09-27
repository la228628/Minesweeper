using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesWheeper
{
    public class CaseMineSpeciale:CaseMine
    {
        public CaseMineSpeciale(int ligne, int colonne) : base(ligne, colonne) { }


        public override void Révéler(Jeu jeuCourant)
        {
            if (jeuCourant.PremiereAction == true)
            {
                jeuCourant.RemplacerCasesDepuis(this.Ligne, this.Colonne);
                jeuCourant.Chronomètre.Start();
                jeuCourant.PremiereAction = false;
            }
            else
            if (!this.EstMarqué &&!this.EstRévélé && !jeuCourant.APerdu && !jeuCourant.AGagné())
            {
                if(!jeuCourant.CompteAReboursModeSpécial.IsRunning)
                {
                    jeuCourant.CommencerCompteARebours();
                }
                else
                {
                    jeuCourant.ValeurDécompteur-=60;
                }
                jeuCourant.DrapeauxRestants--;
                this.EstRévélé = true;

            }

        }
    }
}
