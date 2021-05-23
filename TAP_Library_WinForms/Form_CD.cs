using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;

namespace TAP_Library_WinForms
{
    public partial class Form_CD : Form
    {
        public int? CDCode { get; private set; }
        public bool ReadOnly { get; private set; }
        public bool NewEntry { get; private set; }

        public Form_CD(int? cdCode = null, bool readOnly = false)
        {
            InitializeComponent();
            this.CDCode = cdCode;
            this.ReadOnly = readOnly;
            this.NewEntry = (this.CDCode == null);
            InitializeFields();
        }

        private void InitializeFields()
        {
            X.FormExtensions.DisableButton(button_apply);
            Action<object, EventArgs> enableApply = (sender, e) => X.FormExtensions.EnableButton(button_apply);
            textBox_title.TextChanged += new EventHandler(enableApply);
            comboBox_artist.TextChanged += new EventHandler(enableApply);
            numericUpDown_tracks.ValueChanged += new EventHandler(enableApply);
            if (NewEntry)
            {
                this.Text = "New CD";
                InitializeDropDownLists();
            }
            else
            {
                CD cd = Program.Library.GetCD(this.CDCode.Value);
                if (cd == null)
                {
                    MessageBox.Show("CD not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Text = cd.ToString();
                    textBox_title.Text = cd.Title;
                    comboBox_artist.Text = cd.ArtistName;
                    numericUpDown_tracks.Value = cd.TrackCount;
                    if (this.ReadOnly)
                    {
                        button_undo.Text = "Close";
                        textBox_title.ReadOnly = true;
                        comboBox_artist.Enabled = numericUpDown_tracks.Enabled = false;
                        button_apply.Visible = button_OK.Visible = false;
                    }
                    else
                    {
                        InitializeDropDownLists();
                    }
                }
            }
        }

        private void InitializeDropDownLists()
        {
            comboBox_artist.Items.AddRange(Program.Library.CDArtists);
            comboBox_artist.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_artist.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void Submit(bool closeAfterSubmit = false)
        {
            string title = textBox_title.Text.Trim();
            string artistName = comboBox_artist.Text.Trim();
            int trackCount = (int)numericUpDown_tracks.Value;
            if (title == "" || artistName == "")
            {
                MessageBox.Show("All fields are required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (NewEntry)
                {
                    CD cd = new CD(title, artistName, trackCount);
                    Program.Library.Add(cd);
                    this.NewEntry = false;
                    this.CDCode = cd.Code;
                }
                else
                {
                    Program.Library.Edit(this.CDCode.Value, title, artistName, trackCount);
                }

                InitializeFields();
                ((Form_Main)Application.OpenForms["Form_Main"]).InitializeDataGridView(Program.Library.CDs);

                if (closeAfterSubmit)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Submit(closeAfterSubmit: true);
        }

        private void button_undo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            Submit();
        }
    }
}
