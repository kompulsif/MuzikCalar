namespace PlayerUI
{
    partial class Muziklerim
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
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgwMuziklerim = new System.Windows.Forms.DataGridView();
            this.muzikYonet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listedenKaldırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMuziklerim)).BeginInit();
            this.muzikYonet.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 7;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 47);
            this.panel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "MÜZİKLERİM    ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(486, 384);
            this.panel3.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgwMuziklerim);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 384);
            this.panel1.TabIndex = 10;
            // 
            // dgwMuziklerim
            // 
            this.dgwMuziklerim.AllowUserToAddRows = false;
            this.dgwMuziklerim.AllowUserToDeleteRows = false;
            this.dgwMuziklerim.AllowUserToResizeRows = false;
            this.dgwMuziklerim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwMuziklerim.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(37)))), ((int)(((byte)(76)))));
            this.dgwMuziklerim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwMuziklerim.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgwMuziklerim.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwMuziklerim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwMuziklerim.ColumnHeadersHeight = 25;
            this.dgwMuziklerim.ColumnHeadersVisible = false;
            this.dgwMuziklerim.ContextMenuStrip = this.muzikYonet;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(18)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwMuziklerim.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwMuziklerim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwMuziklerim.EnableHeadersVisualStyles = false;
            this.dgwMuziklerim.GridColor = System.Drawing.Color.Black;
            this.dgwMuziklerim.Location = new System.Drawing.Point(0, 0);
            this.dgwMuziklerim.MultiSelect = false;
            this.dgwMuziklerim.Name = "dgwMuziklerim";
            this.dgwMuziklerim.ReadOnly = true;
            this.dgwMuziklerim.RowHeadersVisible = false;
            this.dgwMuziklerim.RowTemplate.Height = 100;
            this.dgwMuziklerim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwMuziklerim.Size = new System.Drawing.Size(486, 384);
            this.dgwMuziklerim.TabIndex = 60;
            this.dgwMuziklerim.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwMuziklerim_CellDoubleClick);
            // 
            // muzikYonet
            // 
            this.muzikYonet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.muzikYonet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listedenKaldırToolStripMenuItem});
            this.muzikYonet.Name = "icerikYonet";
            this.muzikYonet.ShowImageMargin = false;
            this.muzikYonet.Size = new System.Drawing.Size(156, 48);
            // 
            // listedenKaldırToolStripMenuItem
            // 
            this.listedenKaldırToolStripMenuItem.Name = "listedenKaldırToolStripMenuItem";
            this.listedenKaldırToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.listedenKaldırToolStripMenuItem.Text = "Müziği Sil";
            this.listedenKaldırToolStripMenuItem.Click += new System.EventHandler(this.listedenKaldırToolStripMenuItem_Click);
            // 
            // Muziklerim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(486, 431);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Muziklerim";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMuziklerim)).EndInit();
            this.muzikYonet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgwMuziklerim;
        private System.Windows.Forms.ContextMenuStrip muzikYonet;
        private System.Windows.Forms.ToolStripMenuItem listedenKaldırToolStripMenuItem;
    }
}