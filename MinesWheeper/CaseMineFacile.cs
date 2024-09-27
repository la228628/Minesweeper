using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesWheeper
{
    public class CaseMineFacile:CaseMine
    {
        public CaseMineFacile(int ligne, int colonne) : base(ligne, colonne) { }


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
                if (jeuCourant.NombreVieModeFacile > 1)
                {
                    jeuCourant.NombreVieModeFacile--;
                    jeuCourant.DrapeauxRestants--;
                }
                else
                {
                    jeuCourant.DrapeauxRestants--;
                    jeuCourant.NombreVieModeFacile--;
                    jeuCourant.APerdu = true;
                    jeuCourant.RevelerToutesLesMines();
                    jeuCourant.Chronomètre.Stop();
                }
                this.EstRévélé = true;
            }

        }
    }
}
