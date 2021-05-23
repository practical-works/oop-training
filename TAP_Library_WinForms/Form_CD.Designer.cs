namespace TAP_Library_WinForms
{
    partial class Form_CD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CD));
            this.button_apply = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_undo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.comboBox_artist = new System.Windows.Forms.ComboBox();
            this.numericUpDown_tracks = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tracks)).BeginInit();
            this.SuspendLayout();
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(197, 123);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 7;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(13, 123);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 6;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_undo
            // 
            this.button_undo.Location = new System.Drawing.Point(105, 123);
            this.button_undo.Name = "button_undo";
            this.button_undo.Size = new System.Drawing.Size(75, 23);
            this.button_undo.TabIndex = 5;
            this.button_undo.Text = "Cancel";
            this.button_undo.UseVisualStyleBackColor = true;
            this.button_undo.Click += new System.EventHandler(this.button_undo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_title, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_artist, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_tracks, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 103);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Artist";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tracks";
            // 
            // textBox_title
            // 
            this.textBox_title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_title.Location = new System.Drawing.Point(55, 7);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(202, 20);
            this.textBox_title.TabIndex = 3;
            // 
            // comboBox_artist
            // 
            this.comboBox_artist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_artist.FormattingEnabled = true;
            this.comboBox_artist.Location = new System.Drawing.Point(55, 40);
            this.comboBox_artist.Name = "comboBox_artist";
            this.comboBox_artist.Size = new System.Drawing.Size(202, 21);
            this.comboBox_artist.TabIndex = 4;
            // 
            // numericUpDown_tracks
            // 
            this.numericUpDown_tracks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_tracks.Location = new System.Drawing.Point(55, 75);
            this.numericUpDown_tracks.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_tracks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_tracks.Name = "numericUpDown_tracks";
            this.numericUpDown_tracks.Size = new System.Drawing.Size(202, 20);
            this.numericUpDown_tracks.TabIndex = 5;
            this.numericUpDown_tracks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form_CD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 158);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_undo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CD";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tracks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_undo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.ComboBox comboBox_artist;
        private System.Windows.Forms.NumericUpDown numericUpDown_tracks;
    }
}