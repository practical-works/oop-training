namespace TAP_Library_WinForms
{
    partial class Form_Book
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Book));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.comboBox_author = new System.Windows.Forms.ComboBox();
            this.comboBox_editor = new System.Windows.Forms.ComboBox();
            this.button_undo = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.comboBox_author, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_editor, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 103);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Editor";
            // 
            // textBox_title
            // 
            this.textBox_title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_title.Location = new System.Drawing.Point(55, 7);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(202, 20);
            this.textBox_title.TabIndex = 3;
            // 
            // comboBox_author
            // 
            this.comboBox_author.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_author.FormattingEnabled = true;
            this.comboBox_author.Location = new System.Drawing.Point(55, 40);
            this.comboBox_author.Name = "comboBox_author";
            this.comboBox_author.Size = new System.Drawing.Size(202, 21);
            this.comboBox_author.TabIndex = 4;
            // 
            // comboBox_editor
            // 
            this.comboBox_editor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_editor.FormattingEnabled = true;
            this.comboBox_editor.Location = new System.Drawing.Point(55, 75);
            this.comboBox_editor.Name = "comboBox_editor";
            this.comboBox_editor.Size = new System.Drawing.Size(202, 21);
            this.comboBox_editor.TabIndex = 5;
            // 
            // button_undo
            // 
            this.button_undo.Location = new System.Drawing.Point(105, 123);
            this.button_undo.Name = "button_undo";
            this.button_undo.Size = new System.Drawing.Size(75, 23);
            this.button_undo.TabIndex = 1;
            this.button_undo.Text = "Cancel";
            this.button_undo.UseVisualStyleBackColor = true;
            this.button_undo.Click += new System.EventHandler(this.button_undo_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(13, 123);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(197, 123);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 3;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // Form_Book
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
            this.Name = "Form_Book";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Book";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.ComboBox comboBox_author;
        private System.Windows.Forms.ComboBox comboBox_editor;
        private System.Windows.Forms.Button button_undo;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_apply;
    }
}