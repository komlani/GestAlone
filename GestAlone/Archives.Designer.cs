namespace GestAlone
{
    partial class Archives
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pbCloseArchives = new System.Windows.Forms.PictureBox();
            this.dgvArchivesDep = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvArchivesRec = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMsgActivationCA1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFiltrer = new System.Windows.Forms.Button();
            this.cbCA = new System.Windows.Forms.ComboBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblApropos = new System.Windows.Forms.Label();
            this.btnPrintDep = new System.Windows.Forms.Button();
            this.btnPrintRec = new System.Windows.Forms.Button();
            this.pdDep = new System.Drawing.Printing.PrintDocument();
            this.pdRec = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseArchives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivesDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivesRec)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pbCloseArchives
            // 
            this.pbCloseArchives.BackColor = System.Drawing.Color.White;
            this.pbCloseArchives.BackgroundImage = global::GestAlone.Properties.Resources.error__1_3;
            this.pbCloseArchives.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCloseArchives.Image = global::GestAlone.Properties.Resources.error__1_3;
            this.pbCloseArchives.Location = new System.Drawing.Point(1153, 12);
            this.pbCloseArchives.Name = "pbCloseArchives";
            this.pbCloseArchives.Size = new System.Drawing.Size(35, 35);
            this.pbCloseArchives.TabIndex = 0;
            this.pbCloseArchives.TabStop = false;
            this.pbCloseArchives.Click += new System.EventHandler(this.pbCloseArchives_Click);
            // 
            // dgvArchivesDep
            // 
            this.dgvArchivesDep.AllowUserToAddRows = false;
            this.dgvArchivesDep.AllowUserToDeleteRows = false;
            this.dgvArchivesDep.AllowUserToResizeColumns = false;
            this.dgvArchivesDep.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvArchivesDep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvArchivesDep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArchivesDep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArchivesDep.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvArchivesDep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArchivesDep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(92)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArchivesDep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvArchivesDep.ColumnHeadersHeight = 30;
            this.dgvArchivesDep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvArchivesDep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column1});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(92)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArchivesDep.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvArchivesDep.DoubleBuffered = true;
            this.dgvArchivesDep.EnableHeadersVisualStyles = false;
            this.dgvArchivesDep.HeaderBgColor = System.Drawing.SystemColors.Info;
            this.dgvArchivesDep.HeaderForeColor = System.Drawing.Color.Black;
            this.dgvArchivesDep.Location = new System.Drawing.Point(12, 217);
            this.dgvArchivesDep.MultiSelect = false;
            this.dgvArchivesDep.Name = "dgvArchivesDep";
            this.dgvArchivesDep.ReadOnly = true;
            this.dgvArchivesDep.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArchivesDep.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvArchivesDep.RowHeadersVisible = false;
            this.dgvArchivesDep.RowHeadersWidth = 30;
            this.dgvArchivesDep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchivesDep.Size = new System.Drawing.Size(643, 481);
            this.dgvArchivesDep.TabIndex = 14;
            // 
            // Code
            // 
            this.Code.FillWeight = 50F;
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "a";
            this.dataGridViewTextBoxColumn1.FillWeight = 120F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Date D \'enrégistrement";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "b";
            this.dataGridViewTextBoxColumn3.FillWeight = 140F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Activité Agricole";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "c";
            this.dataGridViewTextBoxColumn4.FillWeight = 200F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Description De La Dépense";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "Montant";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dgvArchivesRec
            // 
            this.dgvArchivesRec.AllowUserToAddRows = false;
            this.dgvArchivesRec.AllowUserToDeleteRows = false;
            this.dgvArchivesRec.AllowUserToResizeColumns = false;
            this.dgvArchivesRec.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvArchivesRec.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArchivesRec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArchivesRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArchivesRec.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvArchivesRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArchivesRec.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(92)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArchivesRec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArchivesRec.ColumnHeadersHeight = 30;
            this.dgvArchivesRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvArchivesRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(92)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArchivesRec.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvArchivesRec.DoubleBuffered = true;
            this.dgvArchivesRec.EnableHeadersVisualStyles = false;
            this.dgvArchivesRec.HeaderBgColor = System.Drawing.SystemColors.Info;
            this.dgvArchivesRec.HeaderForeColor = System.Drawing.Color.Black;
            this.dgvArchivesRec.Location = new System.Drawing.Point(664, 217);
            this.dgvArchivesRec.MultiSelect = false;
            this.dgvArchivesRec.Name = "dgvArchivesRec";
            this.dgvArchivesRec.ReadOnly = true;
            this.dgvArchivesRec.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArchivesRec.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvArchivesRec.RowHeadersVisible = false;
            this.dgvArchivesRec.RowHeadersWidth = 30;
            this.dgvArchivesRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchivesRec.Size = new System.Drawing.Size(516, 481);
            this.dgvArchivesRec.TabIndex = 61;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "Code";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "b";
            this.dataGridViewTextBoxColumn5.FillWeight = 130F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Espece Végétale";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "c";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.FillWeight = 150F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Quantités Récoltées";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "a";
            this.dataGridViewTextBoxColumn2.FillWeight = 140F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Date D \'enrégistrement";
            // 
            // lblMsgActivationCA1
            // 
            this.lblMsgActivationCA1.AutoSize = true;
            this.lblMsgActivationCA1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgActivationCA1.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMsgActivationCA1.Location = new System.Drawing.Point(171, 50);
            this.lblMsgActivationCA1.Name = "lblMsgActivationCA1";
            this.lblMsgActivationCA1.Size = new System.Drawing.Size(838, 29);
            this.lblMsgActivationCA1.TabIndex = 62;
            this.lblMsgActivationCA1.Text = "Listes Des Dépenses Et Récoltes Des Campagnes Agricoles Archivées";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(874, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "Récoltes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(291, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 65;
            this.label1.Text = "Dépenses";
            // 
            // btnFiltrer
            // 
            this.btnFiltrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrer.Location = new System.Drawing.Point(790, 135);
            this.btnFiltrer.Name = "btnFiltrer";
            this.btnFiltrer.Size = new System.Drawing.Size(69, 26);
            this.btnFiltrer.TabIndex = 63;
            this.btnFiltrer.Text = "Filtrer";
            this.btnFiltrer.UseVisualStyleBackColor = true;
            this.btnFiltrer.Click += new System.EventHandler(this.btnFiltrer_Click);
            // 
            // cbCA
            // 
            this.cbCA.DropDownHeight = 100;
            this.cbCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCA.FormattingEnabled = true;
            this.cbCA.IntegralHeight = false;
            this.cbCA.ItemHeight = 18;
            this.cbCA.Location = new System.Drawing.Point(333, 135);
            this.cbCA.Name = "cbCA";
            this.cbCA.Size = new System.Drawing.Size(451, 26);
            this.cbCA.TabIndex = 60;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFooter.Controls.Add(this.lblApropos);
            this.pnlFooter.Location = new System.Drawing.Point(2, 718);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1201, 30);
            this.pnlFooter.TabIndex = 66;
            // 
            // lblApropos
            // 
            this.lblApropos.AutoSize = true;
            this.lblApropos.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApropos.Location = new System.Drawing.Point(521, 4);
            this.lblApropos.Name = "lblApropos";
            this.lblApropos.Size = new System.Drawing.Size(131, 23);
            this.lblApropos.TabIndex = 4;
            this.lblApropos.Text = "f@b|BTS 2019";
            // 
            // btnPrintDep
            // 
            this.btnPrintDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintDep.Location = new System.Drawing.Point(12, 188);
            this.btnPrintDep.Name = "btnPrintDep";
            this.btnPrintDep.Size = new System.Drawing.Size(165, 26);
            this.btnPrintDep.TabIndex = 67;
            this.btnPrintDep.Text = "Imprimer L\'état";
            this.btnPrintDep.UseVisualStyleBackColor = true;
            this.btnPrintDep.Click += new System.EventHandler(this.btnPrintDep_Click);
            // 
            // btnPrintRec
            // 
            this.btnPrintRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintRec.Location = new System.Drawing.Point(1014, 188);
            this.btnPrintRec.Name = "btnPrintRec";
            this.btnPrintRec.Size = new System.Drawing.Size(165, 26);
            this.btnPrintRec.TabIndex = 68;
            this.btnPrintRec.Text = "Imprimer L\'état";
            this.btnPrintRec.UseVisualStyleBackColor = true;
            this.btnPrintRec.Click += new System.EventHandler(this.btnPrintRec_Click);
            // 
            // pdDep
            // 
            this.pdDep.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pdDep_BeginPrint);
            this.pdDep.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdDep_PrintPage);
            // 
            // pdRec
            // 
            this.pdRec.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pdRec_BeginPrint);
            this.pdRec.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdRec_PrintPage);
            // 
            // Archives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.btnPrintRec);
            this.Controls.Add(this.btnPrintDep);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFiltrer);
            this.Controls.Add(this.lblMsgActivationCA1);
            this.Controls.Add(this.dgvArchivesRec);
            this.Controls.Add(this.cbCA);
            this.Controls.Add(this.dgvArchivesDep);
            this.Controls.Add(this.pbCloseArchives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Archives";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archives";
            this.Activated += new System.EventHandler(this.Archives_Activated);
            this.Load += new System.EventHandler(this.Archives_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseArchives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivesDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivesRec)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox pbCloseArchives;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvArchivesDep;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvArchivesRec;
        private System.Windows.Forms.Label lblMsgActivationCA1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFiltrer;
        private System.Windows.Forms.ComboBox cbCA;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblApropos;
        private System.Windows.Forms.Button btnPrintDep;
        private System.Windows.Forms.Button btnPrintRec;
        private System.Drawing.Printing.PrintDocument pdDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Drawing.Printing.PrintDocument pdRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}