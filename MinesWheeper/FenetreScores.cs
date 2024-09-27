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
using System.Diagnostics;

namespace MinesWheeper
{
    public partial class FenetreScores : Form
    {
        private string[] ListeScores;
        public FenetreScores()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.AutoScroll = true;
            this.ListeScores = File.ReadAllLines(@"C:\\Users\\dylan\\source\\repos\\MinesWheeper\\MinesWheeper\\FichierScores.txt");




            for (int i = 0; i < ListeScores.Length; i++)
            {
                if (ListeScores[i] != null)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Location = new Point(20, 50 * i);
                    label.Text = ListeScores[i];
                    label.BorderStyle = BorderStyle.FixedSingle;
                    Debug.WriteLine(ListeScores[i]);

                    if (ListeScores[i].Contains("gagné"))
                    {
                        label.BackColor = Color.LightGreen;
                    }
                    else if (ListeScores[i].Contains("perdu"))
                    {
                        label.BackColor = Color.Red;
                    }
                    this.Controls.Add(label);
                }

            }
        }

        private void FenetreScores_Load(object sender, EventArgs e)
        {
        }






        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
