using System;
using System.Windows.Forms;
using Library;

namespace TAP_Library_WinForms
{
    public partial class Form_Book : Form
    {
        public int? BookCode { get; private set; }
        public bool ReadOnly { get; private set; }
        public bool NewEntry { get; private set; }

        public Form_Book(int? bookCode = null, bool readOnly = false)
        {
            InitializeComponent();
            this.BookCode = bookCode;
            this.ReadOnly = readOnly;
            this.NewEntry = (this.BookCode == null);
            InitializeFields();
        }

        private void InitializeFields()
        {
            X.FormExtensions.DisableButton(button_apply);
            Action<object, EventArgs> enableApply = (sender, e) => X.FormExtensions.EnableButton(button_apply);
            textBox_title.TextChanged += new EventHandler(enableApply);
            comboBox_author.TextChanged += new EventHandler(enableApply);
            comboBox_editor.TextChanged += new EventHandler(enableApply);
            if (NewEntry)
            {
                this.Text = "New book";
                InitializeDropDownLists();
            }
            else
            {
                Book book = Program.Library.GetBook(this.BookCode.Value);
                if (book == null)
                {
                    MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Text = book.ToString();
                    textBox_title.Text = book.Title;
                    comboBox_author.Text = book.AuthorName;
                    comboBox_editor.Text = book.EditorName;
                    if (this.ReadOnly)
                    {
                        button_undo.Text = "Close";
                        textBox_title.ReadOnly = true;
                        comboBox_author.Enabled = comboBox_editor.Enabled = false;
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
            comboBox_author.Items.Clear();
            comboBox_editor.Items.Clear();
            comboBox_author.Items.AddRange(Program.Library.BookAuthors);
            comboBox_editor.Items.AddRange(Program.Library.BookEditors);
            comboBox_author.AutoCompleteMode = comboBox_editor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_author.AutoCompleteSource = comboBox_editor.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void Submit(bool closeAfterSubmit = false)
        {
            string title = textBox_title.Text.Trim();
            string authorName = comboBox_author.Text.Trim();
            string editorName = comboBox_editor.Text.Trim();
            if (title == "" || authorName == "" || editorName == "")
            {
                MessageBox.Show("All fields are required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (NewEntry)
                {
                    Book book = new Book(title, authorName, editorName);
                    Program.Library.Add(book);
                    this.NewEntry = false;
                    this.BookCode = book.Code;
                }
                else
                {
                    Program.Library.Edit(this.BookCode.Value, title, authorName, editorName);
                }

                InitializeFields();
                ((Form_Main)Application.OpenForms["Form_Main"]).InitializeDataGridView(Program.Library.Books);

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
