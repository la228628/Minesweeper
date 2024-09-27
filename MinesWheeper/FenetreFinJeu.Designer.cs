namespace MinesWheeper
{
    partial class FenetreFinJeu
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
            LabelResultatJeu = new Label();
            InputNom = new TextBox();
            BoutonFinir = new Button();
            SuspendLayout();
            // 
            // LabelResultatJeu
            // 
            LabelResultatJeu.AutoSize = true;
            LabelResultatJeu.Location = new Point(167, 36);
            LabelResultatJeu.Name = "LabelResultatJeu";
            LabelResultatJeu.Size = new Size(192, 20);
            LabelResultatJeu.TabIndex = 0;
            LabelResultatJeu.Text = "Ici apparaîtra le texte de fin";
            // 
            // InputNom
            // 
            InputNom.Location = new Point(199, 95);
            InputNom.Name = "InputNom";
            InputNom.PlaceholderText = "Entrez votre nom";
            InputNom.Size = new Size(125, 27);
            InputNom.TabIndex = 1;
            // 
            // BoutonFinir
            // 
            BoutonFinir.Location = new Point(267, 170);
            BoutonFinir.Name = "BoutonFinir";
            BoutonFinir.Size = new Size(94, 29);
            BoutonFinir.TabIndex = 2;
            BoutonFinir.Text = "OK";
            BoutonFinir.UseVisualStyleBackColor = true;
            BoutonFinir.Click += BoutonFinir_Click;
            // 
            // FenetreFinJeu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 213);
            Controls.Add(BoutonFinir);
            Controls.Add(InputNom);
            Controls.Add(LabelResultatJeu);
            MaximumSize = new Size(550, 260);
            MinimumSize = new Size(550, 260);
            Name = "FenetreFinJeu";
            Text = "Jeu terminé";
            Load += FenetreFinJeu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label LabelResultatJeu;
        public TextBox InputNom;
        private Button BoutonFinir;
    }
}