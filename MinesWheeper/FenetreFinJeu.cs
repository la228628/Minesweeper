using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MinesWheeper
{
    public partial class FenetreFinJeu : Form
    {
        private Jeu JeuCourant;
        private StreamWriter sw;

        private string NomJoueur;
        private string GrilleJouée;
        private string ModeJoué;

        private string ResultatPartie;

        public FenetreFinJeu(Jeu jeuCourant)
        {
            InitializeComponent();
            this.JeuCourant = jeuCourant;


            switch (JeuCourant.APerdu)
            {
                case true:
                    this.LabelResultatJeu.Text = "Vous avez perdu, essayez encore!";
                    break;
                case false:
                    this.LabelResultatJeu.Text = "Vous avez gagné, hourra!";
                    break;
            }

            switch (JeuCourant.ModeDeJeu)
            {
                case EModes.Facile:
                    this.ModeJoué = "facile";
                    break;
                case EModes.Normal:
                    this.ModeJoué = "normal";
                    break;
                case EModes.Spécial:
                    this.ModeJoué = "spécial";
                    break;
            }

            switch (JeuCourant.TailleGrille)
            {
                case EConfigGrille.Petite:
                    this.GrilleJouée = "petite grille";
                    break;
                case EConfigGrille.Moyenne:
                    this.GrilleJouée = "grille moyenne";
                    break;
                case EConfigGrille.Grande:
                    this.GrilleJouée = "grande grille";
                    break;
            }

            if (JeuCourant.AGagné() == true)
            {
                this.ResultatPartie = "gagné";
            }
            else if (JeuCourant.APerdu == true)
            {
                this.ResultatPartie = "perdu";
            }



            sw = new StreamWriter("C:\\Users\\dylan\\source\\repos\\MinesWheeper\\MinesWheeper\\FichierScores.txt", true);
        }

        private void BoutonFinir_Click(object sender, EventArgs e)
        {
            if (this.InputNom.Text == "")
            {
                this.NomJoueur = "Joueur";
            }
            else
            {
                this.NomJoueur = this.InputNom.Text;
            }


            sw.WriteLine(this.NomJoueur + " a " + this.ResultatPartie + " la partie en ayant marqué " + JeuCourant.BombesTrouvées + " mines en " + JeuCourant.ConversionEnMinutes(JeuCourant.Chronomètre.ElapsedMilliseconds / 1000) + " minutes en mode " + this.ModeJoué + " dans une " + this.GrilleJouée);
            sw.Close();
            this.Close();
        }

        private void FenetreFinJeu_Load(object sender, EventArgs e)
        {
            this.FormClosing += OnFormClosing_Event;
        }
        private void OnFormClosing_Event(object sender, FormClosingEventArgs e)
        {
            this.sw.Close();
        }
    }
}
