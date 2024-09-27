using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesWheeper
{
    public class CaseMine : Case
    {

        public CaseMine(int ligne, int colonne) : base(ligne, colonne) { }


        public override void Révéler(Jeu jeuCourant)
        {
            if (jeuCourant.PremiereAction == true)
            {
                jeuCourant.Chronomètre.Start();
                jeuCourant.PremiereAction=false;
                jeuCourant.RemplacerCasesDepuis(this.Ligne, this.Colonne);
            }
            else
            if (!this.EstMarqué && !jeuCourant.APerdu && !jeuCourant.AGagné())
            {
                jeuCourant.APerdu = true;
                jeuCourant.RevelerToutesLesMines();
                jeuCourant.Chronomètre.Stop();
                this.EstRévélé = true;
            }
        }

        public override void Marquer(Jeu jeuCourant)
        {
            if (jeuCourant.PremiereAction == true)
            {
                jeuCourant.Chronomètre.Start();
                jeuCourant.PremiereAction = false;
            }
            if (!this.EstRévélé &&!jeuCourant.APerdu && !jeuCourant.AGagné())
            {
                if (this.EstMarqué == false)
                {
                    this.EstMarqué = true;
                    jeuCourant.DrapeauxRestants--;
                    jeuCourant.BombesTrouvées++;
                }
                else if (this.EstMarqué == true)
                {
                    if(this.Interrogation == false)
                    {
                        this.Interrogation = true;
                    }
                    else
                    {
                        this.Interrogation=false;
                        this.EstMarqué = false;
                        jeuCourant.DrapeauxRestants++;
                        jeuCourant.BombesTrouvées--;
                    }
                    
                }
            }

            jeuCourant.PremiereAction = false;
        }
    }
}