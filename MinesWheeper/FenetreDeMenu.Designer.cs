namespace MinesWheeper
{
    partial class FenetreDeMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitre = new Label();
            labelExplication = new Label();
            boutonJouer = new Button();
            boutonScores = new Button();
            boutonQuitter = new Button();
            labelModeConfig = new Label();
            panelBoutonsConfig = new Panel();
            boutonGrande = new RadioButton();
            boutonMoyenne = new RadioButton();
            boutonPetite = new RadioButton();
            boutonFacile = new RadioButton();
            boutonNormal = new RadioButton();
            boutonSpecial = new RadioButton();
            panelBoutonsConfig.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitre
            // 
            labelTitre.AutoSize = true;
            labelTitre.Font = new Font("Segoe UI Black", 45F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitre.Location = new Point(456, 9);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(404, 100);
            labelTitre.TabIndex = 0;
            labelTitre.Text = "Démineur";
            labelTitre.Click += labelTitre_Click;
            // 
            // labelExplication
            // 
            labelExplication.AutoSize = true;
            labelExplication.BorderStyle = BorderStyle.FixedSingle;
            labelExplication.Location = new Point(456, 199);
            labelExplication.MaximumSize = new Size(350, 150);
            labelExplication.Name = "labelExplication";
            labelExplication.Size = new Size(320, 42);
            labelExplication.TabIndex = 1;
            labelExplication.Text = "Veuillez choisir un mode de jeu et une taille de grille avant de continuer";
            labelExplication.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // boutonJouer
            // 
            boutonJouer.Location = new Point(30, 310);
            boutonJouer.Name = "boutonJouer";
            boutonJouer.Size = new Size(94, 29);
            boutonJouer.TabIndex = 2;
            boutonJouer.Text = "Jouer";
            boutonJouer.UseVisualStyleBackColor = true;
            boutonJouer.Visible = false;
            boutonJouer.Click += boutonJouer_Click;
            // 
            // boutonScores
            // 
            boutonScores.Location = new Point(30, 370);
            boutonScores.Name = "boutonScores";
            boutonScores.Size = new Size(94, 29);
            boutonScores.TabIndex = 3;
            boutonScores.Text = "Scores";
            boutonScores.UseVisualStyleBackColor = true;
            boutonScores.Click += boutonScores_Click;
            // 
            // boutonQuitter
            // 
            boutonQuitter.Location = new Point(30, 428);
            boutonQuitter.Name = "boutonQuitter";
            boutonQuitter.Size = new Size(94, 29);
            boutonQuitter.TabIndex = 4;
            boutonQuitter.Text = "Quitter";
            boutonQuitter.UseVisualStyleBackColor = true;
            boutonQuitter.Click += boutonQuitter_Click;
            // 
            // labelModeConfig
            // 
            labelModeConfig.AutoSize = true;
            labelModeConfig.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            labelModeConfig.Location = new Point(861, 197);
            labelModeConfig.MaximumSize = new Size(350, 150);
            labelModeConfig.Name = "labelModeConfig";
            labelModeConfig.Size = new Size(344, 70);
            labelModeConfig.TabIndex = 5;
            labelModeConfig.Text = "Veuillez choisir un mode de jeu et une taille de grille";
            // 
            // panelBoutonsConfig
            // 
            panelBoutonsConfig.Controls.Add(boutonGrande);
            panelBoutonsConfig.Controls.Add(boutonMoyenne);
            panelBoutonsConfig.Controls.Add(boutonPetite);
            panelBoutonsConfig.Location = new Point(1029, 292);
            panelBoutonsConfig.Name = "panelBoutonsConfig";
            panelBoutonsConfig.Size = new Size(191, 165);
            panelBoutonsConfig.TabIndex = 6;
            // 
            // boutonGrande
            // 
            boutonGrande.AutoSize = true;
            boutonGrande.Location = new Point(18, 113);
            boutonGrande.Name = "boutonGrande";
            boutonGrande.Size = new Size(116, 24);
            boutonGrande.TabIndex = 2;
            boutonGrande.TabStop = true;
            boutonGrande.Text = "Grande grille";
            boutonGrande.UseVisualStyleBackColor = true;
            boutonGrande.CheckedChanged += boutonGrande_CheckedChanged;
            // 
            // boutonMoyenne
            // 
            boutonMoyenne.AutoSize = true;
            boutonMoyenne.Location = new Point(18, 62);
            boutonMoyenne.Name = "boutonMoyenne";
            boutonMoyenne.Size = new Size(129, 24);
            boutonMoyenne.TabIndex = 1;
            boutonMoyenne.TabStop = true;
            boutonMoyenne.Text = "Moyenne grille";
            boutonMoyenne.UseVisualStyleBackColor = true;
            boutonMoyenne.CheckedChanged += boutonMoyenne_CheckedChanged;
            // 
            // boutonPetite
            // 
            boutonPetite.AutoSize = true;
            boutonPetite.Location = new Point(18, 18);
            boutonPetite.Name = "boutonPetite";
            boutonPetite.Size = new Size(105, 24);
            boutonPetite.TabIndex = 0;
            boutonPetite.TabStop = true;
            boutonPetite.Text = "Petite grille";
            boutonPetite.UseVisualStyleBackColor = true;
            boutonPetite.CheckedChanged += boutonPetite_CheckedChanged;
            // 
            // boutonFacile
            // 
            boutonFacile.AutoSize = true;
            boutonFacile.Location = new Point(861, 310);
            boutonFacile.Name = "boutonFacile";
            boutonFacile.Size = new Size(67, 24);
            boutonFacile.TabIndex = 7;
            boutonFacile.TabStop = true;
            boutonFacile.Text = "Facile";
            boutonFacile.UseVisualStyleBackColor = true;
            boutonFacile.CheckedChanged += boutonFacile_CheckedChanged;
            // 
            // boutonNormal
            // 
            boutonNormal.AutoSize = true;
            boutonNormal.Location = new Point(861, 354);
            boutonNormal.Name = "boutonNormal";
            boutonNormal.Size = new Size(80, 24);
            boutonNormal.TabIndex = 8;
            boutonNormal.TabStop = true;
            boutonNormal.Text = "Normal";
            boutonNormal.UseVisualStyleBackColor = true;
            boutonNormal.CheckedChanged += boutonNormal_CheckedChanged;
            // 
            // boutonSpecial
            // 
            boutonSpecial.AutoSize = true;
            boutonSpecial.Location = new Point(861, 405);
            boutonSpecial.Name = "boutonSpecial";
            boutonSpecial.Size = new Size(78, 24);
            boutonSpecial.TabIndex = 9;
            boutonSpecial.TabStop = true;
            boutonSpecial.Text = "Spécial";
            boutonSpecial.UseVisualStyleBackColor = true;
            boutonSpecial.CheckedChanged += boutonSpecial_CheckedChanged;
            // 
            // FenetreDeMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 528);
            Controls.Add(boutonSpecial);
            Controls.Add(boutonNormal);
            Controls.Add(boutonFacile);
            Controls.Add(panelBoutonsConfig);
            Controls.Add(labelModeConfig);
            Controls.Add(boutonQuitter);
            Controls.Add(boutonScores);
            Controls.Add(boutonJouer);
            Controls.Add(labelExplication);
            Controls.Add(labelTitre);
            MaximumSize = new Size(1250, 575);
            MinimumSize = new Size(1250, 575);
            Name = "FenetreDeMenu";
            Text = "Menu";
            panelBoutonsConfig.ResumeLayout(false);
            panelBoutonsConfig.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitre;
        private Label labelExplication;
        private Button boutonJouer;
        private Button boutonScores;
        private Button boutonQuitter;
        private Label labelModeConfig;
        private Panel panelBoutonsConfig;
        private RadioButton boutonGrande;
        private RadioButton boutonMoyenne;
        private RadioButton boutonPetite;
        private RadioButton boutonFacile;
        private RadioButton boutonNormal;
        private RadioButton boutonSpecial;
    }
}