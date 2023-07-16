namespace MuzikOynaticisi
{
    partial class ListeleriDuzenle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.listeleriYonet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listeyiSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yenidenAdlandirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeyiCalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dgwListelerim = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgwListeIcerik = new System.Windows.Forms.DataGridView();
            this.icerikYonet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listedenKaldırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.listeleriYonet.SuspendLayout();
            this.tamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListelerim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListeIcerik)).BeginInit();
            this.icerikYonet.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 47);
            this.panel2.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(31, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(769, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "OYNATMA LİSTELERİNİ YONET";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(1, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 7;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listeleriYonet
            // 
            this.listeleriYonet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            this.listeleriYonet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeyiSilToolStripMenuItem,
            this.yenidenAdlandirToolStripMenuItem,
            this.listeyiCalToolStripMenuItem});
            this.listeleriYonet.Name = "eklenenleriYonet";
            this.listeleriYonet.ShowImageMargin = false;
            this.listeleriYonet.Size = new System.Drawing.Size(140, 70);
            // 
            // listeyiSilToolStripMenuItem
            // 
            this.listeyiSilToolStripMenuItem.Name = "listeyiSilToolStripMenuItem";
            this.listeyiSilToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.listeyiSilToolStripMenuItem.Text = "Listeyi Sil";
            this.listeyiSilToolStripMenuItem.Click += new System.EventHandler(this.listeyiSilToolStripMenuItem_Click);
            // 
            // yenidenAdlandirToolStripMenuItem
            // 
            this.yenidenAdlandirToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            this.yenidenAdlandirToolStripMenuItem.Name = "yenidenAdlandirToolStripMenuItem";
            this.yenidenAdlandirToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.yenidenAdlandirToolStripMenuItem.Text = "Yeniden Adlandır";
            this.yenidenAdlandirToolStripMenuItem.Click += new System.EventHandler(this.yenidenAdlandirToolStripMenuItem_Click);
            // 
            // listeyiCalToolStripMenuItem
            // 
            this.listeyiCalToolStripMenuItem.Name = "listeyiCalToolStripMenuItem";
            this.listeyiCalToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.listeyiCalToolStripMenuItem.Text = "Listeyi Çal";
            this.listeyiCalToolStripMenuItem.Click += new System.EventHandler(this.listeyiCalToolStripMenuItem_Click);
            // 
            // tamPanel
            // 
            this.tamPanel.ColumnCount = 2;
            this.tamPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.375F));
            this.tamPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.625F));
            this.tamPanel.Controls.Add(this.dgwListelerim, 0, 1);
            this.tamPanel.Controls.Add(this.label3, 1, 0);
            this.tamPanel.Controls.Add(this.label2, 0, 0);
            this.tamPanel.Controls.Add(this.dgwListeIcerik, 1, 1);
            this.tamPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tamPanel.Location = new System.Drawing.Point(0, 47);
            this.tamPanel.Name = "tamPanel";
            this.tamPanel.RowCount = 2;
            this.tamPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.925558F));
            this.tamPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.07444F));
            this.tamPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tamPanel.Size = new System.Drawing.Size(800, 403);
            this.tamPanel.TabIndex = 72;
            // 
            // dgwListelerim
            // 
            this.dgwListelerim.AllowUserToAddRows = false;
            this.dgwListelerim.AllowUserToDeleteRows = false;
            this.dgwListelerim.AllowUserToResizeRows = false;
            this.dgwListelerim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwListelerim.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(37)))), ((int)(((byte)(76)))));
            this.dgwListelerim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwListelerim.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgwListelerim.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwListelerim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwListelerim.ColumnHeadersHeight = 30;
            this.dgwListelerim.ColumnHeadersVisible = false;
            this.dgwListelerim.ContextMenuStrip = this.listeleriYonet;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Elephant", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwListelerim.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwListelerim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwListelerim.EnableHeadersVisualStyles = false;
            this.dgwListelerim.GridColor = System.Drawing.Color.Black;
            this.dgwListelerim.Location = new System.Drawing.Point(3, 43);
            this.dgwListelerim.MultiSelect = false;
            this.dgwListelerim.Name = "dgwListelerim";
            this.dgwListelerim.ReadOnly = true;
            this.dgwListelerim.RowHeadersVisible = false;
            this.dgwListelerim.RowTemplate.Height = 100;
            this.dgwListelerim.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgwListelerim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwListelerim.Size = new System.Drawing.Size(285, 357);
            this.dgwListelerim.TabIndex = 71;
            this.dgwListelerim.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwListelerim_CellClick);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            this.label3.Location = new System.Drawing.Point(294, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(503, 40);
            this.label3.TabIndex = 70;
            this.label3.Text = "Liste İçeriği";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 40);
            this.label2.TabIndex = 69;
            this.label2.Text = "Listelerim";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgwListeIcerik
            // 
            this.dgwListeIcerik.AllowUserToAddRows = false;
            this.dgwListeIcerik.AllowUserToDeleteRows = false;
            this.dgwListeIcerik.AllowUserToResizeRows = false;
            this.dgwListeIcerik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwListeIcerik.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(37)))), ((int)(((byte)(76)))));
            this.dgwListeIcerik.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwListeIcerik.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgwListeIcerik.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwListeIcerik.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgwListeIcerik.ColumnHeadersHeight = 30;
            this.dgwListeIcerik.ColumnHeadersVisible = false;
            this.dgwListeIcerik.ContextMenuStrip = this.icerikYonet;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Elephant", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwListeIcerik.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgwListeIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwListeIcerik.EnableHeadersVisualStyles = false;
            this.dgwListeIcerik.GridColor = System.Drawing.Color.Black;
            this.dgwListeIcerik.Location = new System.Drawing.Point(294, 43);
            this.dgwListeIcerik.MultiSelect = false;
            this.dgwListeIcerik.Name = "dgwListeIcerik";
            this.dgwListeIcerik.ReadOnly = true;
            this.dgwListeIcerik.RowHeadersVisible = false;
            this.dgwListeIcerik.RowTemplate.Height = 100;
            this.dgwListeIcerik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgwListeIcerik.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwListeIcerik.Size = new System.Drawing.Size(503, 357);
            this.dgwListeIcerik.TabIndex = 67;
            // 
            // icerikYonet
            // 
            this.icerikYonet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            this.icerikYonet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listedenKaldırToolStripMenuItem});
            this.icerikYonet.Name = "icerikYonet";
            this.icerikYonet.ShowImageMargin = false;
            this.icerikYonet.Size = new System.Drawing.Size(156, 48);
            // 
            // listedenKaldırToolStripMenuItem
            // 
            this.listedenKaldırToolStripMenuItem.Name = "listedenKaldırToolStripMenuItem";
            this.listedenKaldırToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.listedenKaldırToolStripMenuItem.Text = "Listeden Kaldır";
            this.listedenKaldırToolStripMenuItem.Click += new System.EventHandler(this.listedenKaldirToolStripMenuItem_Click);
            // 
            // ListeleriDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tamPanel);
            this.Controls.Add(this.panel2);
            this.Name = "ListeleriDuzenle";
            this.Text = "ListeleriDuzenle";
            this.Load += new System.EventHandler(this.ListeleriDuzenle_Load);
            this.panel2.ResumeLayout(false);
            this.listeleriYonet.ResumeLayout(false);
            this.tamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwListelerim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListeIcerik)).EndInit();
            this.icerikYonet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ContextMenuStrip listeleriYonet;
        private System.Windows.Forms.ToolStripMenuItem listeyiSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yenidenAdlandirToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tamPanel;
        private System.Windows.Forms.DataGridView dgwListelerim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgwListeIcerik;
        private System.Windows.Forms.ContextMenuStrip icerikYonet;
        private System.Windows.Forms.ToolStripMenuItem listedenKaldırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeyiCalToolStripMenuItem;
    }
}