using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesWheeper
{
    public partial class FenetreDeMenu : Form
    {

        public EModes ModeSélectionné = EModes.Aucun;
        public EConfigGrille ConfigSélectionnée = EConfigGrille.Aucun;
        private Form1 FenetreALancer;
        private FenetreScores FenetreScores;
        public FenetreDeMenu()
        {
            InitializeComponent();
        }

        private void VerifJouer()
        {
            bool onPeutJouer()
            {
                if (this.ModeSélectionné == EModes.Aucun || this.ConfigSélectionnée == EConfigGrille.Aucun)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (onPeutJouer() == true)
            {
                this.boutonJouer.Visible = true;

            }
            else
            {
                this.boutonJouer.Visible = false;
            }
        }

        private void labelTitre_Click(object sender, EventArgs e)
        {

        }

        private void boutonJouer_Click(object sender, EventArgs e)
        {
            FenetreALancer = new Form1(this);
            FenetreALancer.ShowDialog();
        }

        private void boutonScores_Click(object sender, EventArgs e)
        {
            this.FenetreScores = new FenetreScores();
            this.FenetreScores.ShowDialog();
        }

        private void boutonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void boutonPetite_CheckedChanged(object sender, EventArgs e)
        {
            ConfigSélectionnée = EConfigGrille.Petite; VerifJouer();
        }

        private void boutonMoyenne_CheckedChanged(object sender, EventArgs e)
        {
            ConfigSélectionnée = EConfigGrille.Moyenne; VerifJouer();
        }

        private void boutonGrande_CheckedChanged(object sender, EventArgs e)
        {
            ConfigSélectionnée = EConfigGrille.Grande; VerifJouer();
        }

        private void boutonFacile_CheckedChanged(object sender, EventArgs e)
        {
            this.labelExplication.Text = "Plus facile que le mode normal, vous pouvez toucher 3 mines avant de perdre la partie.";
            ModeSélectionné = EModes.Facile;
            VerifJouer();
        }

        private void boutonNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.labelExplication.Text = "Mode de jeu classique. Lorsque vous cliquez sur une mine, vous perdez.";
            ModeSélectionné = EModes.Normal;
            VerifJouer();
        }

        private void boutonSpecial_CheckedChanged(object sender, EventArgs e)
        {
            this.labelExplication.Text = "Dans ce mode de jeu, lorsque vous touchez une mine, vous ne perdez pas la partie de suite. Si tel est le cas, vous ne disposez que d'un temps limité pour gagner.";
            ModeSélectionné = EModes.Spécial;
            VerifJouer();
        }


    }
}
