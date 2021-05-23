namespace TAP_Library_WinForms
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.dataGridView_works = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_allCD = new System.Windows.Forms.Button();
            this.button_allBooks = new System.Windows.Forms.Button();
            this.button_allWorks = new System.Windows.Forms.Button();
            this.textBox_currentWork = new System.Windows.Forms.TextBox();
            this.textBox_worksCount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_filterWorkType = new System.Windows.Forms.ComboBox();
            this.comboBox_filterWorkProperty = new System.Windows.Forms.ComboBox();
            this.textBox_filterText = new System.Windows.Forms.TextBox();
            this.button_filter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.comboBox_addWorkType = new System.Windows.Forms.ComboBox();
            this.button_edit = new System.Windows.Forms.Button();
            this.textBox_editWorkCode = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox_orderDirection = new System.Windows.Forms.ComboBox();
            this.comboBox_orderWorkProperty = new System.Windows.Forms.ComboBox();
            this.button_order = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox_clear = new System.Windows.Forms.PictureBox();
            this.button_export = new System.Windows.Forms.Button();
            this.button_import = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_return = new System.Windows.Forms.Button();
            this.button_borrow = new System.Windows.Forms.Button();
            this.textBox_borrowWorkCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_works)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clear)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_works
            // 
            this.dataGridView_works.AllowUserToAddRows = false;
            this.dataGridView_works.AllowUserToDeleteRows = false;
            this.dataGridView_works.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_works.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_works.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridView_works.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_works.Location = new System.Drawing.Point(12, 40);
            this.dataGridView_works.Name = "dataGridView_works";
            this.dataGridView_works.ReadOnly = true;
            this.dataGridView_works.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_works.Size = new System.Drawing.Size(467, 310);
            this.dataGridView_works.TabIndex = 0;
            this.dataGridView_works.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_works_CellMouseDoubleClick);
            this.dataGridView_works.CurrentCellChanged += new System.EventHandler(this.dataGridView_works_CurrentCellChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_allCD);
            this.groupBox1.Controls.Add(this.button_allBooks);
            this.groupBox1.Controls.Add(this.button_allWorks);
            this.groupBox1.Controls.Add(this.textBox_currentWork);
            this.groupBox1.Controls.Add(this.textBox_worksCount);
            this.groupBox1.Controls.Add(this.dataGridView_works);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 390);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Works";
            // 
            // button_allCD
            // 
            this.button_allCD.Location = new System.Drawing.Point(204, 359);
            this.button_allCD.Name = "button_allCD";
            this.button_allCD.Size = new System.Drawing.Size(90, 23);
            this.button_allCD.TabIndex = 3;
            this.button_allCD.Text = "All CD";
            this.button_allCD.UseVisualStyleBackColor = true;
            this.button_allCD.Click += new System.EventHandler(this.button_allCD_Click);
            // 
            // button_allBooks
            // 
            this.button_allBooks.Location = new System.Drawing.Point(108, 359);
            this.button_allBooks.Name = "button_allBooks";
            this.button_allBooks.Size = new System.Drawing.Size(90, 23);
            this.button_allBooks.TabIndex = 3;
            this.button_allBooks.Text = "All books";
            this.button_allBooks.UseVisualStyleBackColor = true;
            this.button_allBooks.Click += new System.EventHandler(this.button_allBooks_Click);
            // 
            // button_allWorks
            // 
            this.button_allWorks.Location = new System.Drawing.Point(12, 359);
            this.button_allWorks.Name = "button_allWorks";
            this.button_allWorks.Size = new System.Drawing.Size(90, 23);
            this.button_allWorks.TabIndex = 3;
            this.button_allWorks.Text = "All works";
            this.button_allWorks.UseVisualStyleBackColor = true;
            this.button_allWorks.Click += new System.EventHandler(this.button_allWorks_Click);
            // 
            // textBox_currentWork
            // 
            this.textBox_currentWork.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_currentWork.Location = new System.Drawing.Point(12, 21);
            this.textBox_currentWork.Name = "textBox_currentWork";
            this.textBox_currentWork.ReadOnly = true;
            this.textBox_currentWork.Size = new System.Drawing.Size(467, 13);
            this.textBox_currentWork.TabIndex = 2;
            this.textBox_currentWork.Text = "No selected work";
            // 
            // textBox_worksCount
            // 
            this.textBox_worksCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_worksCount.Location = new System.Drawing.Point(300, 364);
            this.textBox_worksCount.Name = "textBox_worksCount";
            this.textBox_worksCount.ReadOnly = true;
            this.textBox_worksCount.Size = new System.Drawing.Size(179, 13);
            this.textBox_worksCount.TabIndex = 1;
            this.textBox_worksCount.Text = "0 works (0 books, 0 CD)";
            this.textBox_worksCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_filterWorkType);
            this.groupBox2.Controls.Add(this.comboBox_filterWorkProperty);
            this.groupBox2.Controls.Add(this.textBox_filterText);
            this.groupBox2.Controls.Add(this.button_filter);
            this.groupBox2.Location = new System.Drawing.Point(509, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 92);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // comboBox_filterWorkType
            // 
            this.comboBox_filterWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterWorkType.FormattingEnabled = true;
            this.comboBox_filterWorkType.Location = new System.Drawing.Point(177, 27);
            this.comboBox_filterWorkType.Name = "comboBox_filterWorkType";
            this.comboBox_filterWorkType.Size = new System.Drawing.Size(75, 21);
            this.comboBox_filterWorkType.TabIndex = 2;
            this.comboBox_filterWorkType.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterWorkType_SelectedIndexChanged);
            // 
            // comboBox_filterWorkProperty
            // 
            this.comboBox_filterWorkProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterWorkProperty.FormattingEnabled = true;
            this.comboBox_filterWorkProperty.Location = new System.Drawing.Point(13, 53);
            this.comboBox_filterWorkProperty.Name = "comboBox_filterWorkProperty";
            this.comboBox_filterWorkProperty.Size = new System.Drawing.Size(157, 21);
            this.comboBox_filterWorkProperty.TabIndex = 2;
            this.comboBox_filterWorkProperty.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterWorkProperty_SelectedIndexChanged);
            // 
            // textBox_filterText
            // 
            this.textBox_filterText.Location = new System.Drawing.Point(13, 27);
            this.textBox_filterText.Name = "textBox_filterText";
            this.textBox_filterText.Size = new System.Drawing.Size(157, 20);
            this.textBox_filterText.TabIndex = 1;
            // 
            // button_filter
            // 
            this.button_filter.Location = new System.Drawing.Point(177, 52);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(75, 23);
            this.button_filter.TabIndex = 0;
            this.button_filter.Text = "Filter";
            this.button_filter.UseVisualStyleBackColor = true;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_delete);
            this.groupBox3.Controls.Add(this.comboBox_addWorkType);
            this.groupBox3.Controls.Add(this.button_edit);
            this.groupBox3.Controls.Add(this.textBox_editWorkCode);
            this.groupBox3.Controls.Add(this.button_add);
            this.groupBox3.Location = new System.Drawing.Point(509, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 83);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(176, 20);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // comboBox_addWorkType
            // 
            this.comboBox_addWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_addWorkType.FormattingEnabled = true;
            this.comboBox_addWorkType.Location = new System.Drawing.Point(13, 50);
            this.comboBox_addWorkType.Name = "comboBox_addWorkType";
            this.comboBox_addWorkType.Size = new System.Drawing.Size(157, 21);
            this.comboBox_addWorkType.TabIndex = 2;
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(94, 20);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(75, 23);
            this.button_edit.TabIndex = 1;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // textBox_editWorkCode
            // 
            this.textBox_editWorkCode.Location = new System.Drawing.Point(13, 21);
            this.textBox_editWorkCode.Name = "textBox_editWorkCode";
            this.textBox_editWorkCode.Size = new System.Drawing.Size(75, 20);
            this.textBox_editWorkCode.TabIndex = 1;
            this.textBox_editWorkCode.Text = "0";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(176, 49);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 0;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox_orderDirection);
            this.groupBox4.Controls.Add(this.comboBox_orderWorkProperty);
            this.groupBox4.Controls.Add(this.button_order);
            this.groupBox4.Location = new System.Drawing.Point(509, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 53);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Order";
            // 
            // comboBox_orderDirection
            // 
            this.comboBox_orderDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_orderDirection.FormattingEnabled = true;
            this.comboBox_orderDirection.Location = new System.Drawing.Point(115, 19);
            this.comboBox_orderDirection.Name = "comboBox_orderDirection";
            this.comboBox_orderDirection.Size = new System.Drawing.Size(64, 21);
            this.comboBox_orderDirection.TabIndex = 2;
            // 
            // comboBox_orderWorkProperty
            // 
            this.comboBox_orderWorkProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_orderWorkProperty.FormattingEnabled = true;
            this.comboBox_orderWorkProperty.Location = new System.Drawing.Point(13, 19);
            this.comboBox_orderWorkProperty.Name = "comboBox_orderWorkProperty";
            this.comboBox_orderWorkProperty.Size = new System.Drawing.Size(96, 21);
            this.comboBox_orderWorkProperty.TabIndex = 2;
            // 
            // button_order
            // 
            this.button_order.Location = new System.Drawing.Point(184, 18);
            this.button_order.Name = "button_order";
            this.button_order.Size = new System.Drawing.Size(75, 23);
            this.button_order.TabIndex = 0;
            this.button_order.Text = "Order";
            this.button_order.UseVisualStyleBackColor = true;
            this.button_order.Click += new System.EventHandler(this.button_order_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox_clear);
            this.groupBox5.Controls.Add(this.button_export);
            this.groupBox5.Controls.Add(this.button_import);
            this.groupBox5.Controls.Add(this.button_load);
            this.groupBox5.Controls.Add(this.button_save);
            this.groupBox5.Location = new System.Drawing.Point(509, 320);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(265, 82);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save";
            // 
            // pictureBox_clear
            // 
            this.pictureBox_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_clear.Image = global::TAP_Library_WinForms.Properties.Resources.RecycleBinGreen;
            this.pictureBox_clear.Location = new System.Drawing.Point(177, 19);
            this.pictureBox_clear.Name = "pictureBox_clear";
            this.pictureBox_clear.Size = new System.Drawing.Size(73, 50);
            this.pictureBox_clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_clear.TabIndex = 1;
            this.pictureBox_clear.TabStop = false;
            this.pictureBox_clear.Click += new System.EventHandler(this.pictureBox_clear_Click);
            this.pictureBox_clear.MouseEnter += new System.EventHandler(this.pictureBox_clear_MouseEnter);
            this.pictureBox_clear.MouseLeave += new System.EventHandler(this.pictureBox_clear_MouseLeave);
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(13, 46);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(75, 23);
            this.button_export.TabIndex = 0;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(94, 46);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(75, 23);
            this.button_import.TabIndex = 0;
            this.button_import.Text = "Import";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(94, 19);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_save
            // 
            this.button_save.Enabled = false;
            this.button_save.Location = new System.Drawing.Point(13, 19);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 0;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_return);
            this.groupBox6.Controls.Add(this.button_borrow);
            this.groupBox6.Controls.Add(this.textBox_borrowWorkCode);
            this.groupBox6.Location = new System.Drawing.Point(509, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(259, 56);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Borrowing";
            // 
            // button_return
            // 
            this.button_return.Location = new System.Drawing.Point(175, 19);
            this.button_return.Name = "button_return";
            this.button_return.Size = new System.Drawing.Size(75, 23);
            this.button_return.TabIndex = 1;
            this.button_return.Text = "Return";
            this.button_return.UseVisualStyleBackColor = true;
            this.button_return.Click += new System.EventHandler(this.button_return_Click);
            // 
            // button_borrow
            // 
            this.button_borrow.Location = new System.Drawing.Point(94, 19);
            this.button_borrow.Name = "button_borrow";
            this.button_borrow.Size = new System.Drawing.Size(75, 23);
            this.button_borrow.TabIndex = 0;
            this.button_borrow.Text = "Borrow";
            this.button_borrow.UseVisualStyleBackColor = true;
            this.button_borrow.Click += new System.EventHandler(this.button_borrow_Click);
            // 
            // textBox_borrowWorkCode
            // 
            this.textBox_borrowWorkCode.Location = new System.Drawing.Point(13, 20);
            this.textBox_borrowWorkCode.Name = "textBox_borrowWorkCode";
            this.textBox_borrowWorkCode.Size = new System.Drawing.Size(75, 20);
            this.textBox_borrowWorkCode.TabIndex = 1;
            this.textBox_borrowWorkCode.Text = "0";
            this.textBox_borrowWorkCode.TextChanged += new System.EventHandler(this.textBox_borrowWorkCode_TextChanged);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 414);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_works)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clear)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_works;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox_filterWorkType;
        private System.Windows.Forms.ComboBox comboBox_filterWorkProperty;
        private System.Windows.Forms.TextBox textBox_filterText;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ComboBox comboBox_orderWorkProperty;
        private System.Windows.Forms.Button button_order;
        private System.Windows.Forms.ComboBox comboBox_orderDirection;
        private System.Windows.Forms.ComboBox comboBox_addWorkType;
        private System.Windows.Forms.TextBox textBox_editWorkCode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_worksCount;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_currentWork;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_return;
        private System.Windows.Forms.Button button_borrow;
        private System.Windows.Forms.TextBox textBox_borrowWorkCode;
        private System.Windows.Forms.Button button_allCD;
        private System.Windows.Forms.Button button_allBooks;
        private System.Windows.Forms.Button button_allWorks;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.PictureBox pictureBox_clear;
    }
}

