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
    public partial class Form_Main : Form
    {
        private Library.WorkCollection WorkLibrary = Program.Library;

        public Form_Main()
        {
            InitializeComponent();

            InitializeCollectionsCounts();

            InitializeFilterWorkTypesDropDownList();
            InitializeFilterWorkPropertiesDropDownList();

            InitializeOrderWorkPropertiesDropDownList();
            InitializeOrderDirectionDropDownList();

            InitializeAddWorkTypesDropDownList();

            X.FormExtensions.EnableButton(button_allWorks);
            button_allWorks_Click(new object(), new EventArgs());
        }

        #region Initializers
        public void InitializeDataGridView(object dataSource = null)
        {
            dataGridView_works.DataSource = null;
            dataGridView_works.DataSource = (dataSource == null) ?  WorkLibrary.Works : dataSource;
            InitializeCollectionsCounts();
            if (dataSource is List<Book>)
            {
                X.FormExtensions.DisableButton(button_allBooks);
                X.FormExtensions.EnableButton(button_allWorks);
                X.FormExtensions.EnableButton(button_allCD);
            }
            else if (dataSource is List<CD>)
            {
                X.FormExtensions.DisableButton(button_allCD);
                X.FormExtensions.EnableButton(button_allBooks);
                X.FormExtensions.EnableButton(button_allWorks);
            }
            else
            {
                X.FormExtensions.DisableButton(button_allWorks);
                X.FormExtensions.EnableButton(button_allBooks);
                X.FormExtensions.EnableButton(button_allCD);
            }
        }
        private void InitializeCollectionsCounts()
        {
            textBox_worksCount.Text = string.Format("{0} works ({1} books, {2} CD)",
                WorkLibrary.WorkCount, WorkLibrary.BookCount, WorkLibrary.CDCount);
        }
        private void InitializeAddWorkTypesDropDownList()
        {
            comboBox_addWorkType.Items.Clear();
            comboBox_addWorkType.Items.AddRange(
                Enum.GetNames(typeof(Library.WorkCollection.WorkType)).Skip(1).ToArray<string>()
            );
            comboBox_addWorkType.SelectedIndex = 0;
        }
        private void InitializeOrderWorkPropertiesDropDownList()
        {
            comboBox_orderDirection.Items.Clear();
            comboBox_orderDirection.Items.AddRange(Enum.GetNames(typeof(Library.WorkCollection.OrderDirection)));
            comboBox_orderDirection.SelectedIndex = 0;
        }
        private void InitializeOrderDirectionDropDownList()
        {
            comboBox_orderWorkProperty.Items.Clear();
            comboBox_orderWorkProperty.Items.AddRange(Enum.GetNames(typeof(Library.WorkCollection.WorkProperties)));
            comboBox_orderWorkProperty.SelectedIndex = 0;
        }
        private void InitializeFilterWorkTypesDropDownList()
        {
            comboBox_filterWorkType.Items.Clear();
            comboBox_filterWorkType.Items.AddRange(Enum.GetNames(typeof(Library.WorkCollection.WorkType)));
            comboBox_filterWorkType.SelectedIndex = 0;
        }
        private void InitializeFilterWorkPropertiesDropDownList()
        {
            comboBox_filterWorkProperty.Items.Clear();
            switch (comboBox_filterWorkType.SelectedIndex)
            {
                case (int)Library.WorkCollection.WorkType.Work:
                    comboBox_filterWorkProperty.Items.AddRange
                        (Enum.GetNames(typeof(Library.WorkCollection.WorkProperties)));
                    break;
                case (int)Library.WorkCollection.WorkType.Book:
                    comboBox_filterWorkProperty.Items.AddRange
                        (Enum.GetNames(typeof(Library.WorkCollection.BookProperties)));
                    break;
                case (int)Library.WorkCollection.WorkType.CD:
                    comboBox_filterWorkProperty.Items.AddRange
                        (Enum.GetNames(typeof(Library.WorkCollection.CDProperties)));
                    break;
                default:
                    break;
            }
            if (comboBox_filterWorkProperty.Items.Count != 0)
            {
                comboBox_filterWorkProperty.SelectedIndex = 0;
            }
        }
        #endregion

        #region Work Types Switchers
        private void button_allWorks_Click(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }
        private void button_allBooks_Click(object sender, EventArgs e)
        {
            InitializeDataGridView(WorkLibrary.Books);
        }
        private void button_allCD_Click(object sender, EventArgs e)
        {
            InitializeDataGridView(WorkLibrary.CDs);
        }
        #endregion

        #region Borrowing
        private void SwitchBorrowingButtons(Work currentWork)
        {
            if (currentWork != null)
            {
                button_borrow.Enabled = currentWork.State;
                button_return.Enabled = !currentWork.State;
            }
            else
            {
                button_borrow.Enabled = button_borrow.Enabled = false;
            }
        }
        private void button_borrow_Click(object sender, EventArgs e)
        {
            int workCode = 0;
            if (!int.TryParse(textBox_borrowWorkCode.Text, out workCode))
            {
                MessageBox.Show("Invalid work code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(WorkLibrary.Borrow(workCode), "Borrow work", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitializeDataGridView();
            }
        }
        private void button_return_Click(object sender, EventArgs e)
        {
            int workCode = 0;
            if (!int.TryParse(textBox_borrowWorkCode.Text, out workCode))
            {
                MessageBox.Show("Invalid work code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(WorkLibrary.Return(workCode), "Return borrowed work", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitializeDataGridView();
            }
        }
        #endregion

        #region Search
        private void SearchWorkByProperty(string input)
        {
            List<Work> resultList = new List<Work>();
            switch ((WorkCollection.WorkProperties)comboBox_filterWorkProperty.SelectedIndex)
            {
                case WorkCollection.WorkProperties.Code:
                    int workCode = 0;
                    if (!int.TryParse(input, out workCode))
                    {
                        MessageBox.Show("Invalid input for searching by code.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        resultList.Add(WorkLibrary.GetWork(workCode));
                    }
                    break;
                case WorkCollection.WorkProperties.Title:
                    resultList.AddRange(WorkLibrary.GetWorks(input));
                    break;
                case WorkCollection.WorkProperties.State:
                    if (input.Contains("no"))
                    {
                        resultList.AddRange(WorkLibrary.GetWorks(false));
                    }
                    else
                    {
                        resultList.AddRange(WorkLibrary.GetWorks(true));
                    }
                    break;
                case WorkCollection.WorkProperties.BorrowCount:
                    int borrowCount = 0;
                    if (!int.TryParse(input, out borrowCount))
                    {
                        MessageBox.Show("Invalid input for searching by borrow count.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        resultList.AddRange(WorkLibrary.GetWorks(borrowCount));
                    }
                    break;
                default:
                    break;
            }
            if (resultList.Count != 0 && resultList[0] == null)
            {
                resultList.Clear();
            }
            InitializeDataGridView(resultList);
        }
        private void SearchBookByProperty(string input)
        {
            List<Book> resultList = new List<Book>();
            switch ((WorkCollection.BookProperties)comboBox_filterWorkProperty.SelectedIndex)
            {
                case WorkCollection.BookProperties.Code:
                    int bookCode = 0;
                    if (!int.TryParse(input, out bookCode))
                    {
                        MessageBox.Show("Invalid input for searching by code.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        resultList.Add(WorkLibrary.GetBook(bookCode));
                    }
                    break;
                case WorkCollection.BookProperties.Title:
                    resultList.AddRange(WorkLibrary.GetBooks(input));
                    break;
                case WorkCollection.BookProperties.State:
                    if (input.Contains("no"))
                    {
                        resultList.AddRange(WorkLibrary.GetBooks(false));
                    }
                    else
                    {
                        resultList.AddRange(WorkLibrary.GetBooks(true));
                    }
                    break;
                case WorkCollection.BookProperties.BorrowCount:
                    int borrowCount = 0;
                    if (!int.TryParse(input, out borrowCount))
                    {
                        MessageBox.Show("Invalid input for searching by borrow count.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        resultList.AddRange(WorkLibrary.GetBooks(borrowCount));
                    }
                    break;
                case WorkCollection.BookProperties.AuthorName:
                    resultList.AddRange(WorkLibrary.GetBooksByAuthor(input));
                    break;
                case WorkCollection.BookProperties.EditorName:
                    resultList.AddRange(WorkLibrary.GetBooksByEditor(input));
                    break;
                default:
                    break;
            }
            if (resultList.Count != 0 && resultList[0] == null)
            {
                resultList.Clear();
            }
            InitializeDataGridView(resultList);
        }
        private void SearchCDByProperty(string input)
        {
            List<CD> resultList = new List<CD>();
            switch ((WorkCollection.CDProperties)comboBox_filterWorkProperty.SelectedIndex)
            {
                case WorkCollection.CDProperties.Code:
                    int CDCode = 0;
                    if (!int.TryParse(input, out CDCode))
                    {
                        MessageBox.Show("Invalid input for searching by code.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        resultList.Add(WorkLibrary.GetCD(CDCode));
                    }
                    break;
                case WorkCollection.CDProperties.Title:
                    resultList.AddRange(WorkLibrary.GetCDs(input));
                    break;
                case WorkCollection.CDProperties.State:
                    if (input.Contains("no"))
                    {
                        resultList.AddRange(WorkLibrary.GetCDs(false));
                    }
                    else
                    {
                        resultList.AddRange(WorkLibrary.GetCDs(true));
                    }
                    break;
                case WorkCollection.CDProperties.BorrowCount:
                    int borrowCount = 0;
                    if (!int.TryParse(input, out borrowCount))
                    {
                        MessageBox.Show("Invalid input for searching by borrow count.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        resultList.AddRange(WorkLibrary.GetCDs(borrowCount));
                    }
                    break;
                case WorkCollection.CDProperties.ArtistName:
                    resultList.AddRange(WorkLibrary.GetCDsByArtist(input));
                    break;
                case WorkCollection.CDProperties.TrackCount:
                    int trackCount = 0;
                    if (!int.TryParse(input, out trackCount))
                    {
                        MessageBox.Show("Invalid input for searching by track count.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        resultList.AddRange(WorkLibrary.GetCDsByTrackCount(trackCount));
                    }
                    break;
                default:
                    break;
            }
            if (resultList.Count != 0 && resultList[0] == null)
            {
                resultList.Clear();
            }
            InitializeDataGridView(resultList);
        }
        private void button_filter_Click(object sender, EventArgs e)
        {
            string input = textBox_filterText.Text.Trim();
            if (input == "")
            {
                MessageBox.Show("Empty field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_filterText.Focus();
            }
            else
            {
                switch ((WorkCollection.WorkType)comboBox_filterWorkType.SelectedIndex)
                {
                    case WorkCollection.WorkType.Work:
                        SearchWorkByProperty(input);
                        break;
                    case WorkCollection.WorkType.Book:
                        SearchBookByProperty(input);
                        break;
                    case WorkCollection.WorkType.CD:
                        SearchCDByProperty(input);
                        break;
                    default:
                        break;
                }
            }
        }
        private void comboBox_filterWorkProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_filterWorkProperty.SelectedIndex == (int)WorkCollection.WorkProperties.State)
            {
                textBox_filterText.Text = "not available";
            }
            textBox_filterText.Focus();
        }
        private void comboBox_filterWorkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeFilterWorkPropertiesDropDownList();
        }
        #endregion

        #region Order
        private void button_order_Click(object sender, EventArgs e)
        {
            InitializeDataGridView(WorkLibrary.Order((WorkCollection.WorkProperties)comboBox_orderWorkProperty.SelectedIndex,
                (WorkCollection.OrderDirection)comboBox_orderDirection.SelectedIndex));
        }
        #endregion

        #region Update
        private void button_add_Click(object sender, EventArgs e)
        {
            if ((comboBox_addWorkType.SelectedIndex + 1) == (int)WorkCollection.WorkType.Book)
            {
                Form_Book addBookForm = new Form_Book();
                addBookForm.ShowDialog(this);
            }   
            else
            {
                Form_CD addCDForm = new Form_CD();
                addCDForm.ShowDialog(this);
            }
        }
        private void button_edit_Click(object sender, EventArgs e)
        {
            int workCode = 0;
            if (!int.TryParse(textBox_editWorkCode.Text.Trim(), out workCode))
            {
                MessageBox.Show("Invalid work code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (WorkLibrary.GetWork(workCode) is Book)
                {
                    Form_Book addBookForm = new Form_Book(workCode);
                    addBookForm.ShowDialog(this);
                }
                else
                {
                    Form_CD addCDForm = new Form_CD(workCode);
                    addCDForm.ShowDialog(this);
                }
            }
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            int workCode = 0;
            if (!int.TryParse(textBox_editWorkCode.Text.Trim(), out workCode))
            {
                MessageBox.Show("Invalid work code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Work work = WorkLibrary.GetWork(workCode);
                if (work == null)
                {
                    MessageBox.Show("Work not found.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (MessageBox.Show("This work will be deleted :\n" + work.ToString(), "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    WorkLibrary.Delete(workCode);
                    InitializeDataGridView();
                }
            }
        }
        #endregion

        #region DataGrid
        private void dataGridView_works_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView senderDGV = (DataGridView)sender;
            if (dataGridView_works.Rows.Count != 0 && senderDGV.CurrentRow != null)
            {
                int currentWorkCode = (int)senderDGV.CurrentRow.Cells["Code"].Value;
                Work currentWork = WorkLibrary.GetWork(currentWorkCode);
                textBox_currentWork.Text = currentWork.ToString();
                textBox_borrowWorkCode.Text = textBox_editWorkCode.Text = currentWorkCode.ToString();
            }
        }
        private void dataGridView_works_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int workCode = (int)dataGridView_works.Rows[e.RowIndex].Cells["Code"].Value;
                if (WorkLibrary.GetWork(workCode) is Book)
                {
                    Form_Book addBookForm = new Form_Book(workCode, readOnly: true);
                    addBookForm.ShowDialog(this);
                }
                else
                {
                    Form_CD addCDForm = new Form_CD(workCode, readOnly: true);
                    addCDForm.ShowDialog(this);
                }
            }
        }
        #endregion

        private void textBox_borrowWorkCode_TextChanged(object sender, EventArgs e)
        {
            int workCode = 0;
            Work work = null;
            if (int.TryParse(textBox_borrowWorkCode.Text.Trim(), out workCode))
            {
                work = WorkLibrary.GetWork(workCode);
            }
            SwitchBorrowingButtons(work);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (WorkLibrary.WorkCount == 0)
            {
                MessageBox.Show("Nothing to save.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(WorkLibrary.SaveToDataBase(), "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            if (WorkLibrary.LoadFromDataBase() == 0)
            {
                MessageBox.Show("Nothing to load.\nDatabase maybe empty or denying access.", "Loading", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InitializeDataGridView();
            }
        }

        private void FileDialogConfig(FileDialog fileDialog)
        {
            fileDialog.Filter = WorkCollection.FileTypeFilter;
            fileDialog.DefaultExt = "library";
            fileDialog.AddExtension = true;
            fileDialog.FileName = (fileDialog is SaveFileDialog) ?
                "Library_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") : "";
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                FileDialogConfig(saveFileDialog);
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    WorkCollection.FileType fileType = (WorkCollection.FileType)saveFileDialog.FilterIndex - 1;
                    WorkLibrary.ExportToFile(fileType, filePath);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Could not export data to file.\n\n" + x.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                FileDialogConfig(openFileDialog);
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    WorkCollection.FileType fileType = (WorkCollection.FileType)openFileDialog.FilterIndex - 1;
                    WorkLibrary.ImportFromFile(fileType, filePath);
                    InitializeDataGridView();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Could not import data from file.\n\n" + x.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox_clear_Click(object sender, EventArgs e)
        {
            WorkLibrary.Works.Clear();
            InitializeDataGridView();
        }

        private void pictureBox_clear_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_clear.Image = TAP_Library_WinForms.Properties.Resources.RecycleBinGreen;
        }

        private void pictureBox_clear_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_clear.Image = TAP_Library_WinForms.Properties.Resources.RecycleBinRed;
        }
    }
}
