namespace BCA_MakingAnIA
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.BtnRec = new System.Windows.Forms.Button();
            this.TxtInput = new System.Windows.Forms.TextBox();
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.BtnModeConsole = new System.Windows.Forms.Button();
            this.Tm_LL = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnRec
            // 
            this.BtnRec.BackColor = System.Drawing.SystemColors.Control;
            this.BtnRec.Location = new System.Drawing.Point(233, 237);
            this.BtnRec.Name = "BtnRec";
            this.BtnRec.Size = new System.Drawing.Size(27, 23);
            this.BtnRec.TabIndex = 0;
            this.BtnRec.UseVisualStyleBackColor = false;
            this.BtnRec.Click += new System.EventHandler(this.BtnRec_Click);
            // 
            // TxtInput
            // 
            this.TxtInput.Location = new System.Drawing.Point(12, 38);
            this.TxtInput.Multiline = true;
            this.TxtInput.Name = "TxtInput";
            this.TxtInput.Size = new System.Drawing.Size(113, 156);
            this.TxtInput.TabIndex = 1;
            // 
            // TxtOutput
            // 
            this.TxtOutput.Location = new System.Drawing.Point(147, 38);
            this.TxtOutput.Multiline = true;
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.Size = new System.Drawing.Size(113, 156);
            this.TxtOutput.TabIndex = 2;
            // 
            // BtnModeConsole
            // 
            this.BtnModeConsole.Location = new System.Drawing.Point(12, 237);
            this.BtnModeConsole.Name = "BtnModeConsole";
            this.BtnModeConsole.Size = new System.Drawing.Size(113, 23);
            this.BtnModeConsole.TabIndex = 3;
            this.BtnModeConsole.Text = "Mode Console";
            this.BtnModeConsole.UseVisualStyleBackColor = true;
            this.BtnModeConsole.Click += new System.EventHandler(this.BtnModeConsole_Click);
            // 
            // Tm_LL
            // 
            this.Tm_LL.Enabled = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(150, 5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(128, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 20);
            this.toolStripMenuItem1.Text = " ";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 272);
            this.Controls.Add(this.BtnModeConsole);
            this.Controls.Add(this.TxtOutput);
            this.Controls.Add(this.TxtInput);
            this.Controls.Add(this.BtnRec);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "[BCA] IA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRec;
        private System.Windows.Forms.TextBox TxtInput;
        private System.Windows.Forms.TextBox TxtOutput;
        private System.Windows.Forms.Button BtnModeConsole;
        private System.Windows.Forms.Timer Tm_LL;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

