namespace GestAlone
{
    partial class FormConnexion
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
            this.tbIdGerant = new System.Windows.Forms.TextBox();
            this.pnlUnderIdGerant = new System.Windows.Forms.Panel();
            this.pnlUnderMdpGerant = new System.Windows.Forms.Panel();
            this.tbMdpGerant = new System.Windows.Forms.TextBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.pnlMsgError = new System.Windows.Forms.Panel();
            this.lblMsgErreurConn = new System.Windows.Forms.Label();
            this.pbImgConn = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgConn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // tbIdGerant
            // 
            this.tbIdGerant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdGerant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdGerant.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbIdGerant.Location = new System.Drawing.Point(48, 152);
            this.tbIdGerant.Name = "tbIdGerant";
            this.tbIdGerant.Size = new System.Drawing.Size(195, 16);
            this.tbIdGerant.TabIndex = 2;
            this.tbIdGerant.Text = "Identifiant";
            this.tbIdGerant.Enter += new System.EventHandler(this.tbIdGerant_Enter);
            this.tbIdGerant.Leave += new System.EventHandler(this.tbIdGerant_Leave);
            // 
            // pnlUnderIdGerant
            // 
            this.pnlUnderIdGerant.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlUnderIdGerant.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlUnderIdGerant.Location = new System.Drawing.Point(48, 171);
            this.pnlUnderIdGerant.Name = "pnlUnderIdGerant";
            this.pnlUnderIdGerant.Size = new System.Drawing.Size(205, 2);
            this.pnlUnderIdGerant.TabIndex = 3;
            // 
            // pnlUnderMdpGerant
            // 
            this.pnlUnderMdpGerant.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlUnderMdpGerant.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlUnderMdpGerant.Location = new System.Drawing.Point(48, 206);
            this.pnlUnderMdpGerant.Name = "pnlUnderMdpGerant";
            this.pnlUnderMdpGerant.Size = new System.Drawing.Size(205, 2);
            this.pnlUnderMdpGerant.TabIndex = 4;
            // 
            // tbMdpGerant
            // 
            this.tbMdpGerant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMdpGerant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMdpGerant.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbMdpGerant.Location = new System.Drawing.Point(48, 187);
            this.tbMdpGerant.Name = "tbMdpGerant";
            this.tbMdpGerant.Size = new System.Drawing.Size(200, 16);
            this.tbMdpGerant.TabIndex = 5;
            this.tbMdpGerant.Text = "Mot De Passe";
           
            this.tbMdpGerant.Enter += new System.EventHandler(this.tbMdpGerant_Enter);
            this.tbMdpGerant.Leave += new System.EventHandler(this.tbMdpGerant_Leave);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnAnnuler.FlatAppearance.BorderSize = 2;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGreen;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnAnnuler.Location = new System.Drawing.Point(153, 237);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(100, 31);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // pnlMsgError
            // 
            this.pnlMsgError.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlMsgError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMsgError.Location = new System.Drawing.Point(0, 315);
            this.pnlMsgError.Name = "pnlMsgError";
            this.pnlMsgError.Size = new System.Drawing.Size(300, 60);
            this.pnlMsgError.TabIndex = 8;
            // 
            // lblMsgErreurConn
            // 
            this.lblMsgErreurConn.AutoSize = true;
            this.lblMsgErreurConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMsgErreurConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgErreurConn.ForeColor = System.Drawing.Color.Red;
            this.lblMsgErreurConn.Location = new System.Drawing.Point(46, 280);
            this.lblMsgErreurConn.Name = "lblMsgErreurConn";
            this.lblMsgErreurConn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMsgErreurConn.Size = new System.Drawing.Size(0, 22);
            this.lblMsgErreurConn.TabIndex = 0;
            this.lblMsgErreurConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbImgConn
            // 
            this.pbImgConn.BackgroundImage = global::GestAlone.Properties.Resources.lock1;
            this.pbImgConn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImgConn.Location = new System.Drawing.Point(94, 41);
            this.pbImgConn.Name = "pbImgConn";
            this.pbImgConn.Size = new System.Drawing.Size(109, 68);
            this.pbImgConn.TabIndex = 1;
            this.pbImgConn.TabStop = false;
            // 
            // pbClose
            // 
            this.pbClose.BackgroundImage = global::GestAlone.Properties.Resources.error__1_3;
            this.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbClose.Image = global::GestAlone.Properties.Resources.error__1_3;
            this.pbClose.Location = new System.Drawing.Point(262, 9);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(30, 30);
            this.pbClose.TabIndex = 0;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // btnConnexion
            // 
            this.btnConnexion.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnConnexion.FlatAppearance.BorderSize = 2;
            this.btnConnexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGreen;
            this.btnConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnexion.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnConnexion.Location = new System.Drawing.Point(48, 237);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(100, 31);
            this.btnConnexion.TabIndex = 6;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(300, 375);
            this.Controls.Add(this.lblMsgErreurConn);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.tbMdpGerant);
            this.Controls.Add(this.pnlUnderMdpGerant);
            this.Controls.Add(this.pnlUnderIdGerant);
            this.Controls.Add(this.tbIdGerant);
            this.Controls.Add(this.pbImgConn);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.pnlMsgError);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConnexion";
            this.Load += new System.EventHandler(this.FormConnexion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgConn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbImgConn;
        private System.Windows.Forms.TextBox tbIdGerant;
        private System.Windows.Forms.Panel pnlUnderIdGerant;
        private System.Windows.Forms.Panel pnlUnderMdpGerant;
        private System.Windows.Forms.TextBox tbMdpGerant;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Panel pnlMsgError;
        private System.Windows.Forms.Label lblMsgErreurConn;
        private System.Windows.Forms.Button btnConnexion;




    }
}

