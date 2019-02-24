namespace Morpion_Evolution
{
    partial class Morpion_Evolution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Morpion_Evolution));
            this.cmdRestart = new System.Windows.Forms.Button();
            this.lblJoueur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdRestart
            // 
            this.cmdRestart.BackColor = System.Drawing.Color.Transparent;
            this.cmdRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRestart.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRestart.ForeColor = System.Drawing.Color.DimGray;
            this.cmdRestart.Location = new System.Drawing.Point(158, 495);
            this.cmdRestart.Name = "cmdRestart";
            this.cmdRestart.Size = new System.Drawing.Size(132, 43);
            this.cmdRestart.TabIndex = 10;
            this.cmdRestart.Tag = 82;
            this.cmdRestart.Text = "Restart";
            this.cmdRestart.UseVisualStyleBackColor = false;
            this.cmdRestart.Click += new System.EventHandler(this.cmdRestart_Click);
            // 
            // lblJoueur
            // 
            this.lblJoueur.AutoSize = true;
            this.lblJoueur.BackColor = System.Drawing.Color.Transparent;
            this.lblJoueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJoueur.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueur.ForeColor = System.Drawing.Color.Red;
            this.lblJoueur.Location = new System.Drawing.Point(100, 445);
            this.lblJoueur.Name = "lblJoueur";
            this.lblJoueur.Size = new System.Drawing.Size(259, 36);
            this.lblJoueur.TabIndex = 11;
            this.lblJoueur.Text = "1st player\'s turn ( X )";
            // 
            // Morpion_Evolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::Morpion_Evolution.Properties.Resources.FE;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(448, 550);
            this.Controls.Add(this.lblJoueur);
            this.Controls.Add(this.cmdRestart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Morpion_Evolution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Morpion Evolution";
            this.Load += new System.EventHandler(this.Morpion_Evolution_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdRestart;
        private System.Windows.Forms.Label lblJoueur;
    }
}