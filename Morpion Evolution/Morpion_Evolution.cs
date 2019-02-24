using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;


namespace Morpion_Evolution
{
    public partial class Morpion_Evolution : Form
    {
        private Panel[] pnlArray = new Panel[9];
        private Button[] btnArray = new Button[81];
        private int[] coordXPnl = new int[9] { 12, 157, 302, 12, 157, 302, 12, 157, 302 };
        private int[] coordYPnl = new int[9] { 12, 12, 12, 157, 157, 157, 302, 302, 302 };
        private int[] coordXBtn = new int[9] { 0, 46, 92, 0, 46, 92, 0, 46, 92 };
        private int[] coordYBtn = new int[9] { 0, 0, 0, 46, 46, 46, 92, 92, 92 };
        private bool Joueur = true;//Sert à savoir à qui c'est le tour de jouer
        private int[][] pnlArrayArray = new int[10][];
        private Control[] pnlGagnes = new Control[9];
        private int nbrPnlGagnes = 0;


        public Morpion_Evolution()
        {
            InitializeComponent();
        }
        public void createForms()
        {
            for (int i = 0; i < 9; i++)//Création des 9 panels
            {
                Panel pnl = new Panel();
                pnl.BackColor = System.Drawing.Color.Transparent;
                pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                pnl.ForeColor = System.Drawing.Color.DimGray;
                pnl.Location = new System.Drawing.Point(coordXPnl[i], coordYPnl[i]);
                pnl.Name = "pnlCase" + (i + 1);
                pnl.TabIndex = i + 1;
                pnl.Tag = 111 * (i + 1);
                pnl.Size = new System.Drawing.Size(132, 132);

                for (int j = 1; j < 10; j++)//Création des 9 boutons pour un panel
                {
                    Button btn = new Button();
                    btn.BackColor = System.Drawing.Color.Transparent;
                    btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.ForeColor = System.Drawing.Color.DimGray;
                    btn.Location = new System.Drawing.Point(coordXBtn[j - 1], coordYBtn[j - 1]);
                    btn.Name = "cmdCase" + (i * 9 + j);
                    btn.Size = new System.Drawing.Size(40, 40);
                    btn.TabIndex = j;
                    btn.Tag = i * 9 + j;
                    btn.UseVisualStyleBackColor = true;
                    btn.Click += new System.EventHandler(cmdBtn_Click);

                    btnArray[i * 9 + j - 1] = btn;
                }
                for (int k = i * 9; k < i * 9 + 9; k++)//On ajoute 9 boutons à chaque panel
                {
                    pnl.Controls.Add(btnArray[k]);
                }
                pnlArray[i] = pnl;// Remplie le tableau de panels pour pouvoir nommer et appeler UN panel dans la suite du code
            }
        }
        private void cmdBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//récupère le bouton par lequel on est arrivé ici

            Control pnlParent = btn.Parent;//récupère le panel qui contient le bouton par lequel on est arrivé dans cette fonction
            Panel pnlCible = pnlArray[btn.TabIndex - 1];//Panel dans lequel le prochain joueur doit jouer
            int nbrPoints;
            if (Joueur)//Pour le système de victoire
            {
                nbrPoints = 3;
                btn.BackgroundImage = Properties.Resources.croix_rouge;
            }
            else
            {
                nbrPoints = 5;
                btn.BackgroundImage = Properties.Resources.cercle_bleu;
            }

            switch (btn.TabIndex)
            {
                case 1:
                    pnlArrayArray[pnlParent.TabIndex][0] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][5] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][6] += nbrPoints;
                    break;
                case 2:
                    pnlArrayArray[pnlParent.TabIndex][0] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][4] += nbrPoints;
                    break;
                case 3:
                    pnlArrayArray[pnlParent.TabIndex][0] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][3] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][7] += nbrPoints;
                    break;
                case 4:
                    pnlArrayArray[pnlParent.TabIndex][1] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][5] += nbrPoints;
                    break;
                case 5:
                    pnlArrayArray[pnlParent.TabIndex][1] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][4] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][6] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][7] += nbrPoints;
                    break;
                case 6:
                    pnlArrayArray[pnlParent.TabIndex][1] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][3] += nbrPoints;
                    break;
                case 7:
                    pnlArrayArray[pnlParent.TabIndex][2] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][5] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][7] += nbrPoints;
                    break;
                case 8:
                    pnlArrayArray[pnlParent.TabIndex][2] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][4] += nbrPoints;
                    break;
                case 9:
                    pnlArrayArray[pnlParent.TabIndex][2] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][3] += nbrPoints;
                    pnlArrayArray[pnlParent.TabIndex][6] += nbrPoints;
                    break;
            }
            TestVictoireOuEgalite(pnlParent, btn, nbrPoints);

            if (pnlGagnes.Contains(pnlCible))
            {
                activerPanels();
                pnlCible.Enabled = false;
            }
            else
            {
                desactiverPanels();
                pnlCible.Enabled = true;
            }
            desactiverPnlGagnes();
            btn.Enabled = false;
            Joueur = !Joueur;
            if (Joueur == false)
            {
                lblJoueur.Location = new System.Drawing.Point(95, 445);
                lblJoueur.Text = "2nd player's turn ( O )";
                lblJoueur.ForeColor = System.Drawing.Color.DodgerBlue;
            }
            else
            {
                lblJoueur.Location = new System.Drawing.Point(100, 445);
                lblJoueur.Text = "1st player's turn ( X )";
                lblJoueur.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void desactiverPnlGagnes()
        {
            foreach (Panel pnl in pnlArray)
            {
                if (pnl.BackgroundImage != null)
                {
                    pnl.Enabled = false;
                }
            }
        }
        private void TestVictoireOuEgalite(Control pnl, Button btn, int nbrPoints)
        {
            if (Joueur)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (pnlArrayArray[pnl.TabIndex][i] == 9)//Si 3 croix alors le panel devient une croix
                    {
                        pnl.BackgroundImage = Properties.Resources.croix_rouge;
                        majPnlArrayArray(btn, nbrPoints);
                        nbrPnlGagnes++;
                        pnlGagnes[nbrPnlGagnes - 1] = pnl;

                        if (pnlArrayArray[0][i] == 9)//Si trois panels croix sont aligné alors victoire
                        {
                            pnl.BackgroundImage = Properties.Resources.croix_rouge;
                            BackgroundImage = Properties.Resources.FE2;
                            this.Enabled = false;
                            break;
                        }
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)//Idem avec cercle
                {
                    if (pnlArrayArray[pnl.TabIndex][i] == 15)
                    {
                        pnl.BackgroundImage = Properties.Resources.cercle_bleu;
                        majPnlArrayArray(btn, nbrPoints);
                        nbrPnlGagnes++;
                        pnlGagnes[nbrPnlGagnes - 1] = pnl;

                        if (pnlArrayArray[0][i] == 15)
                        {
                            pnl.BackgroundImage = Properties.Resources.cercle_bleu;
                            BackgroundImage = Properties.Resources.FE2;
                            this.Enabled = false;
                            break;
                        }
                        break;
                    }
                }
            }
        }
        private void majPnlArrayArray(Button btn, int nbrPoints)
        {
            Control pnlParent = btn.Parent;
            switch (btn.TabIndex)
            {
                case 1:
                    pnlArrayArray[0][0] += nbrPoints;
                    pnlArrayArray[0][5] += nbrPoints;
                    pnlArrayArray[0][6] += nbrPoints;
                    break;
                case 2:
                    pnlArrayArray[0][0] += nbrPoints;
                    pnlArrayArray[0][4] += nbrPoints;
                    break;
                case 3:
                    pnlArrayArray[0][0] += nbrPoints;
                    pnlArrayArray[0][3] += nbrPoints;
                    pnlArrayArray[0][7] += nbrPoints;
                    break;
                case 4:
                    pnlArrayArray[0][1] += nbrPoints;
                    pnlArrayArray[0][5] += nbrPoints;
                    break;
                case 5:
                    pnlArrayArray[0][1] += nbrPoints;
                    pnlArrayArray[0][4] += nbrPoints;
                    pnlArrayArray[0][6] += nbrPoints;
                    pnlArrayArray[0][7] += nbrPoints;
                    break;
                case 6:
                    pnlArrayArray[0][1] += nbrPoints;
                    pnlArrayArray[0][3] += nbrPoints;
                    break;
                case 7:
                    pnlArrayArray[0][2] += nbrPoints;
                    pnlArrayArray[0][5] += nbrPoints;
                    pnlArrayArray[0][7] += nbrPoints;
                    break;
                case 8:
                    pnlArrayArray[0][2] += nbrPoints;
                    pnlArrayArray[0][4] += nbrPoints;
                    break;
                case 9:
                    pnlArrayArray[0][2] += nbrPoints;
                    pnlArrayArray[0][3] += nbrPoints;
                    pnlArrayArray[0][6] += nbrPoints;
                    break;
            }
        }
        private void viderBloc1()
        {
            for (int i = 0; i < 9; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderBloc2()
        {
            for (int i = 9; i < 18; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderBloc3()
        {
            for (int i = 18; i < 27; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderBloc4()
        {
            for (int i = 27; i < 36; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderBloc5()
        {
            for (int i = 36; i < 45; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderBloc6()
        {
            for (int i = 45; i < 54; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderBloc7()
        {
            for (int i = 54; i < 63; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderBloc8()
        {
            for (int i = 63; i < 72; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderBloc9()
        {
            for (int i = 72; i < 81; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void viderCases()
        {
            for (int i = 0; i < 81; i++)
            {
                btnArray[i].BackgroundImage = null;
            }
        }
        private void activerBloc1()
        {
            for (int i = 0; i < 9; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerBloc2()
        {
            for (int i = 9; i < 18; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerBloc3()
        {
            for (int i = 18; i < 27; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerBloc4()
        {
            for (int i = 27; i < 36; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerBloc5()
        {
            for (int i = 36; i < 45; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerBloc6()
        {
            for (int i = 45; i < 54; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerBloc7()
        {
            for (int i = 54; i < 63; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerBloc8()
        {
            for (int i = 63; i < 72; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerBloc9()
        {
            for (int i = 72; i < 81; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void activerCasesRestart()
        {
            for (int i = 0; i < 81; i++)
            {
                btnArray[i].Enabled = true;
            }
        }
        private void desactiverPanels()
        {
            for (int i = 0; i < 9; i++)
            {
                pnlArray[i].Enabled = false;
            }
        }
        private void activerPanels()
        {
            for (int i = 0; i < 9; i++)
            {
                pnlArray[i].Enabled = true;
            }
        }
        private void viderPanels()
        {
            for (int i = 0; i < 9; i++)
            {
                pnlArray[i].BackgroundImage = null;
            }
        }
        private void cmdRestart_Click(object sender, EventArgs e)
        {
            InitTab();
            Joueur = true;
            viderPanels();
            viderCases();
            activerCasesRestart();
            activerPanels();
            BackgroundImage = Properties.Resources.FE;
        }
        private void InitTab()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pnlArrayArray[i][j] = 0;
                }
            }
        }
        private void Morpion_Evolution_Load(object sender, EventArgs e)
        {
            createForms();
            for (int i = 0; i < 10; i++)
            {
                pnlArrayArray[i] = new int[8];
            }
            InitTab();
            foreach (Panel pnl in pnlArray)//Ajoute les panels à la fenêtre
            {
                this.Controls.Add(pnl);
            }
        }
    }
}