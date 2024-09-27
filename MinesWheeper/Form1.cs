using System.Diagnostics;
using System.Drawing.Text;
using static System.Windows.Forms.LinkLabel;

namespace MinesWheeper
{
    public partial class Form1 : Form
    {
        private FenetreDeMenu Menu;


        static Image drapeaubase = Image.FromFile("drapeau.png");
        public static Image drapeau = new Bitmap(drapeaubase, 50, 50);
        static Image coeurRougeBase = Image.FromFile("coeurRouge.png");
        public static Image coeurRouge = new Bitmap(coeurRougeBase, 25, 25);
        static Image coeurNoirBase = Image.FromFile("coeurNoir.png");
        public static Image coeurNoir = new Bitmap(coeurNoirBase, 25, 25);
        public static Image bombebase = Image.FromFile("bombe.png");
        public static Image bombe = new Bitmap(bombebase, 50, 50);
        public static Image interrobase = Image.FromFile("Interrogation.png");
        public static Image interrogation = new Bitmap(interrobase, 50, 50);


        public Jeu JeuCourant;
        public int LignesTableau;
        public int ColonnesTableau;

        public EConfigGrille ConfigChoisie;
        public EModes ModeChoisi;

        Button[,] TableauBoutons;




        private Label LabelChrono;
        private System.Windows.Forms.Timer Temps;


        public Label LabelDrapeaux;


        public Label[] TabCoeur;


        public Label LabelCompteARebours;

        public FenetreFinJeu FinCourante;

        public Form1(FenetreDeMenu menu)
        {
            this.WindowState = FormWindowState.Maximized;
            Temps = new System.Windows.Forms.Timer();
            Temps.Start();
            Temps.Tick += new EventHandler(AvancéeDuTemps);



            Menu = menu;
            ModeChoisi = Menu.ModeSélectionné;
            ConfigChoisie = Menu.ConfigSélectionnée;

            switch (this.ModeChoisi)
            {
                case EModes.Facile:
                    this.BackColor = Color.LightGreen;
                    TabCoeur = new Label[3];
                    for (int i = 0; i < TabCoeur.Length; i++)
                    {
                        TabCoeur[i] = new Label();
                        TabCoeur[i].Image = coeurRouge;
                        TabCoeur[i].Location = new System.Drawing.Point(1550 + i * 100, 100);
                        this.Controls.Add(TabCoeur[i]);
                    }
                    break;


                case EModes.Normal:
                    this.BackColor = Color.LightGray;
                    break;


                case EModes.Spécial:
                    this.BackColor = Color.HotPink;
                    LabelCompteARebours = new Label();
                    LabelCompteARebours.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                    LabelCompteARebours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    LabelCompteARebours.Font = new Font("Arial Narrow", 15);
                    LabelCompteARebours.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                    LabelCompteARebours.Location = new System.Drawing.Point(1600, 100);
                    LabelCompteARebours.MinimumSize = new System.Drawing.Size(200, 32);
                    this.Controls.Add(LabelCompteARebours);
                    break;
            }



            JeuCourant = new Jeu(ModeChoisi, ConfigChoisie);



            LignesTableau = JeuCourant.GrilleCourante.Lignes;
            ColonnesTableau = JeuCourant.GrilleCourante.Colonnes;
            this.TableauBoutons = new Button[LignesTableau, ColonnesTableau];




            LabelDrapeaux = new Label();
            LabelDrapeaux.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            LabelDrapeaux.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            LabelDrapeaux.Font = new Font("Arial Narrow", 15);
            LabelDrapeaux.TextAlign = ContentAlignment.MiddleCenter;
            LabelDrapeaux.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            LabelDrapeaux.Location = new System.Drawing.Point(1600, 200);
            LabelDrapeaux.MinimumSize = new System.Drawing.Size(50, 32);
            LabelDrapeaux.Text = this.JeuCourant.DrapeauxRestants.ToString() + " ⚑";
            this.Controls.Add(LabelDrapeaux);




            LabelChrono = new Label();
            LabelChrono.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            LabelChrono.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            LabelChrono.Font = new Font("Arial Narrow", 15);
            LabelChrono.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            LabelChrono.Location = new System.Drawing.Point(1600, 150);
            LabelChrono.MinimumSize = new System.Drawing.Size(200, 32);
            this.Controls.Add(LabelChrono);


            InitializeComponent();

            AfficherLesBoutons();
        }


        public void AfficherLesBoutons()
        {
            for (int i = 0; i < LignesTableau; i++)
            {
                for (int j = 0; j < ColonnesTableau; j++)
                {
                    Button bouton = new Button();
                    Case caseDeRef = this.JeuCourant.RenvoyerCaseA(i, j);

                    bouton.Width = 50;
                    bouton.Height = 50;
                    bouton.BackColor = Color.DarkGray;
                    bouton.ForeColor = Color.White;
                    bouton.FlatStyle = FlatStyle.Popup;
                    bouton.Location = new Point(50 + j * 50, 50 + i * 50);
                    bouton.Font = new Font("Arial", 20, FontStyle.Bold);

                    object[] DonneesTag = new object[] { i, j };
                    //Debug pour savoir où sont les mines
                    switch (caseDeRef)
                    {
                        case CaseVide:
                            bouton.Text = " ";
                            break;

                        case CaseMine:
                           //bouton.Text = "M";
                            break;
                    }
                    //
                    bouton.Tag = (DonneesTag);

                    bouton.MouseDown += MettreEnSurbrillance;
                    bouton.MouseUp += GestionDesClics;
                    this.Controls.Add(bouton);
                    TableauBoutons[i, j] = bouton;
                }
            }
        }


        public void MettreEnSurbrillance(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            object[] DonneesBouton = (object[])button.Tag;


            int ligneCourante = (int)DonneesBouton[0];
            int colonneCourante = (int)DonneesBouton[1];

            if (e.Button == MouseButtons.Left)
            {
                for (int i = ligneCourante - 1; i <= ligneCourante + 1; i++)
                {
                    for (int j = colonneCourante - 1; j <= colonneCourante + 1; j++)
                    {
                        if (this.TableauBoutons.ContientLaCoordonée(i, j))
                        {
                            if (i == ligneCourante && j == colonneCourante)
                            {
                                continue;
                            }
                            else
                            {
                                this.TableauBoutons[i, j].BackColor = Color.Gray;
                            }
                        }
                    }
                }
            }
        }


        public void GestionDesClics(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;


            object[] DonneesBouton = (object[])button.Tag;


            int ligneCourante = (int)DonneesBouton[0];
            int colonneCourante = (int)DonneesBouton[1];

            if (e.Button == MouseButtons.Right)
            {
                //Debug.WriteLine("Droite");
                this.JeuCourant.GrilleCourante.TableauDeCase[ligneCourante, colonneCourante].Marquer(this.JeuCourant);
            }


            if (e.Button == MouseButtons.Left)
            {
                this.JeuCourant.GrilleCourante.TableauDeCase[ligneCourante, colonneCourante].Révéler(this.JeuCourant);

                button.BackColor = Color.Gray;
            }

            MajTableau(ligneCourante, colonneCourante);
        }




        public void MajTableau(int ligne, int colonne)
        {
            //Debug pour savoir où est la mine remplacée
            for (int i = 0; i < TableauBoutons.GetLength(0); i++)
            {
                for (int j = 0; j < TableauBoutons.GetLength(1); j++)
                {
                    if (JeuCourant.RenvoyerCaseA(i, j) is CaseMine && this.TableauBoutons[i, j].Text != "M")
                    {
                        //this.TableauBoutons[i, j].Text = "M";
                        this.TableauBoutons[i, j].ForeColor = Color.Black;
                    }

                }
            }

            ///




            //clic gauche
            for (int i = 0; i < JeuCourant.GrilleCourante.TableauDeCase.GetLength(0); i++)
            {
                for (int j = 0; j < JeuCourant.GrilleCourante.TableauDeCase.GetLength(1); j++)
                {
                    //clic gauche
                    if (JeuCourant.RenvoyerCaseA(i, j).EstRévélé == true)
                    {
                        switch (JeuCourant.RenvoyerCaseA(i, j))
                        {

                            case CaseVide:
                                if (JeuCourant.RenvoyerCaseA(i, j).NombreBombesAdjacentes != 0)
                                {
                                    TableauBoutons[i, j].Text = JeuCourant.RenvoyerCaseA(i, j).NombreBombesAdjacentes.ToString();
                                    switch (JeuCourant.RenvoyerCaseA(i, j).NombreBombesAdjacentes)
                                    {
                                        case 1:
                                            TableauBoutons[i, j].ForeColor = Color.Blue;
                                            break;
                                        case 2:
                                            TableauBoutons[i, j].ForeColor = Color.Green;

                                            break;
                                        case 3:
                                            TableauBoutons[i, j].ForeColor = Color.Red;

                                            break;
                                        case 4:
                                            TableauBoutons[i, j].ForeColor = Color.DarkBlue;

                                            break;
                                        case 5:
                                            TableauBoutons[i, j].ForeColor = Color.DarkRed;

                                            break;
                                        case 6:
                                            TableauBoutons[i, j].ForeColor = Color.Cyan;

                                            break;

                                        case 7:
                                            TableauBoutons[i, j].ForeColor = Color.Black;

                                            break;

                                        case 8:
                                            TableauBoutons[i, j].ForeColor = Color.LightGray;

                                            break;
                                    }
                                }
                                else
                                {
                                    TableauBoutons[i, j].Text = "";
                                }
                                TableauBoutons[i, j].BackColor = Color.Gray;
                                break;

                            case CaseMine:
                                TableauBoutons[i, j].Image = bombe;
                                switch (this.JeuCourant.NombreVieModeFacile)
                                {
                                    case 2:
                                        this.TabCoeur[0].Image = coeurNoir;
                                        break;
                                    case 1:
                                        this.TabCoeur[1].Image = coeurNoir;
                                        break;
                                    case 0:
                                        this.TabCoeur[2].Image = coeurNoir;
                                        break;
                                    default:
                                        break;

                                }
                                TableauBoutons[i, j].BackColor = Color.Gray;
                                break;
                        }
                    }
                    else
                    {
                        TableauBoutons[i,j].BackColor = Color.DarkGray;
                    }
                }
            }



            ////////////////////////////////////

            //clic droit


            if (JeuCourant.RenvoyerCaseA(ligne, colonne).EstRévélé == false)
            {
                switch (JeuCourant.RenvoyerCaseA(ligne, colonne).EstMarqué)
                {
                    case true:
                        if (JeuCourant.RenvoyerCaseA(ligne, colonne).Interrogation == true)
                        {
                            TableauBoutons[ligne, colonne].Image = interrogation;
                        }
                        else
                        {
                            TableauBoutons[ligne, colonne].Image = drapeau;
                            TableauBoutons[ligne, colonne].BackColor = Color.DarkGray;
                        }
                        break;
                    case false:
                        TableauBoutons[ligne, colonne].Image = null;
                        break;
                }
            }

            //////////////
            LabelDrapeaux.Text = this.JeuCourant.DrapeauxRestants.ToString() + " ⚑";
        }


        private void AvancéeDuTemps(object sender, EventArgs e)
        {
            this.LabelChrono.Text = "Temps écoulé " + JeuCourant.ConversionEnMinutes( JeuCourant.Chronomètre.ElapsedMilliseconds / 1000 );
            if (this.ModeChoisi == EModes.Spécial)
            {
                this.LabelCompteARebours.Text = "Reste " + JeuCourant.ConversionEnMinutes(JeuCourant.ValeurDécompteur - JeuCourant.CompteAReboursModeSpécial.ElapsedMilliseconds / 1000);
            }
            if (this.JeuCourant.APerdu == true || this.JeuCourant.AGagné()==true)
            {
                this.Temps.Stop();
                this.FinCourante = new FenetreFinJeu(this.JeuCourant);
                this.FinCourante.ShowDialog();
                this.Close();
            }
        }
    }
}