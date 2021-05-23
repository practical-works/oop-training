using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Library
{
    public class WorkCollection
    {
        #region Attributes & Properties
        private List<Work> _works = new List<Work>();
        public int WorkCount { get { return _works.Count; } }
        public int BookCount { get { return _works.Count(w => w is Book); } }
        public int CDCount { get { return _works.Count(w => w is CD); } }
        public List<Work> Works { get { return _works; } }
        public List<Book> Books
        {
            get 
            {
                List<Book> bookList = new List<Book>();
                _works.Where(w => w is Book).ToList().ForEach(w => bookList.Add((Book)w));
                return bookList;
            }
        }
        public List<CD> CDs
        {
            get
            {
                List<CD> CDList = new List<CD>();
                _works.Where(w => w is CD).ToList().ForEach(w => CDList.Add((CD)w));
                return CDList;
            }
        }
        public string[] BookAuthors { get { return Books.Select(b => b.AuthorName).ToArray<string>(); } }
        public string[] BookEditors { get { return Books.Select(b => b.EditorName).ToArray<string>(); } }
        public string[] CDArtists { get { return CDs.Select(c => c.ArtistName).ToArray<string>(); } }
        public enum WorkSituation { NotFound, NotAvailable, Available }
        public enum WorkType { Work, Book, CD }
        public enum WorkProperties { Code, Title, State, BorrowCount }
        public enum BookProperties { Code, Title, State, BorrowCount, AuthorName, EditorName }
        public enum CDProperties { Code, Title, State, BorrowCount, ArtistName, TrackCount }
        public enum OrderDirection { Ascending, Descending }
        public enum FileType { LIBRARY, TXT, INI, XML, JSON }
        public static string FileTypeFilter
        {
            get
            {
                return "Library binary file|*.library|"
                       + "Plain text file|*.txt; *.text|"
                       + "INI text file*|.ini|"
                       + "XML document file|*.xml|"
                       + "JSON document file|*.json";
            }
        }
        #endregion

        #region Constructors
        public WorkCollection()
        {
            //_works = new List<Work>()
            //{
            //    new Book("work_1", "some author C", "some editor B"),
            //    new Book("work_2", "some author D", "some editor B"),
            //    new Book("work_3", "some author F", "some editor B"),
            //    new Book("work_4", "some author A", "some editor C"),
            //    new Book("work_5", "some author K", "some editor A"),
            //    new Book("work_6", "some author L", "some editor Z"),
            //    new Book("work_7", "some author K", "some editor X"),
            //    new CD("work_8", "some artist A", 3),
            //    new CD("work_9", "some artist C", 10),
            //    new CD("work_10", "some artist A", 7),
            //    new CD("work_11", "some artist B", 1),
            //    new CD("work_12", "some artist Z", 33),
            //    new CD("work_13", "some artist L", 10),
            //    new CD("work_14", "some artist X", 8),
            //    new CD("work_15", "some artist Y", 17),
            //    new CD("work_16", "some artist Z", 2),
            //    new Book("work_17", "some author A", "some editor X"),
            //    new Book("work_18", "some author B", "some editor X"),
            //    new Book("work_19", "some author K", "some editorG"),
            //    new Book("work_20", "some author C", "some editor J")
            //};
            //_works[0].Borrow();
            //_works[1].Borrow();
            //_works[2].Borrow();
        }
        #endregion

        #region Methods
        // Borrowing
        public WorkSituation GetWorkSituation(int workCode)
        {
            Work work = GetWork(workCode);
            if (work == null)
            {
                return WorkSituation.NotFound;
            }
            else if (work.State == false)
            {
                return WorkSituation.NotAvailable;
            }
            return WorkSituation.Available;
        }
        public string Borrow(int workCode)
        {
            WorkSituation workSituation = GetWorkSituation(workCode);
            if (workSituation == WorkSituation.NotFound)
            {
                return "Work not found.";
            }
            else if (workSituation == WorkSituation.NotAvailable)
            {
                return "Work not available for borrowing.";
            } 
            else
	        {
                return _works.Find(w => w.Code == workCode).Borrow();
	        }
        }
        public string Return(int workCode)
        {
            WorkSituation workSituation = GetWorkSituation(workCode);
            if (workSituation == WorkSituation.NotFound)
            {
                return "Work not found.";
            }
            else if (workSituation == WorkSituation.Available)
            {
                return "Work is already available.";
            }
            else
            {
                return _works.Find(w => w.Code == workCode).Return();
            }
        }

        // Search
        public Work GetWork(int workCode)
        {
            return _works.Find(w => w.Code == workCode);
        }
            // Search Works
        public List<Work> GetWorks(string workTitle)
        {
            return _works.FindAll(w => w.Title.ToLower().Contains(workTitle.ToLower()));
        }
        public List<Work> GetWorks(bool workState)
        {
            return _works.FindAll(w => w.State == workState);
        }
        public List<Work> GetWorks(int workBorrowCount)
        {
            return _works.FindAll(w => w.BorrowCount == workBorrowCount);
        }
            // Search Books
        public Book GetBook(int bookCode)
        {
            return (Book)_works.Find(w => w.Code == bookCode);
        }
        public List<Book> GetBooks(string bookTitle)
        {
            return Books.FindAll(b => b.Title.ToLower().Contains(bookTitle.ToLower()));
        }
        public List<Book> GetBooks(bool bookState)
        {
            return Books.FindAll(b => b.State == bookState);
        }
        public List<Book> GetBooks(int bookBorrowCount)
        {
            return Books.FindAll(b => b.BorrowCount == bookBorrowCount);
        }
        public List<Book> GetBooksByAuthor(string bookAuthorName)
        {
            return Books.FindAll(b => b.AuthorName == bookAuthorName);
        }
        public List<Book> GetBooksByEditor(string bookEditorName)
        {
            return Books.FindAll(b => b.EditorName == bookEditorName);
        }
            // Search CDs
        public CD GetCD(int CDCode)
        {
            return (CD)_works.Find(w => w.Code == CDCode);
        }
        public List<CD> GetCDs(string CDTitle)
        {
            return CDs.FindAll(c => c.Title.ToLower().Contains(CDTitle.ToLower()));
        }
        public List<CD> GetCDs(bool CDState)
        {
            return CDs.FindAll(c => c.State == CDState);
        }
        public List<CD> GetCDs(int CDBorrowCount)
        {
            return CDs.FindAll(c => c.BorrowCount == CDBorrowCount);
        }
        public List<CD> GetCDsByArtist(string CDArtistName)
        {
            return CDs.FindAll(c => c.ArtistName == CDArtistName);
        }
        public List<CD> GetCDsByTrackCount(int CDTrackCount)
        {
            return CDs.FindAll(c => c.TrackCount == CDTrackCount);
        }

        // Order
        public List<Work> Order(WorkProperties workProperty, OrderDirection orderDirection)
        {
            if (orderDirection == OrderDirection.Ascending)
            {
                switch (workProperty)
                {
                    case WorkProperties.Code:
                        return Works.OrderBy(w => w.Code).ToList();
                    case WorkProperties.Title:
                        return Works.OrderBy(w => w.Title).ToList();
                    case WorkProperties.State:
                        return Works.OrderBy(w => w.State).ToList();
                    case WorkProperties.BorrowCount:
                        return Works.OrderBy(w => w.BorrowCount).ToList();
                    default:
                        return null;
                }
            }
            else
            {
                switch (workProperty)
                {
                    case WorkProperties.Code:
                        return Works.OrderByDescending(w => w.Code).ToList();
                    case WorkProperties.Title:
                        return Works.OrderByDescending(w => w.Title).ToList();
                    case WorkProperties.State:
                        return Works.OrderByDescending(w => w.State).ToList();
                    case WorkProperties.BorrowCount:
                        return Works.OrderByDescending(w => w.BorrowCount).ToList();
                    default:
                        return null;
                }
            }
        }

        // Update
        public bool Add(Work work)
        {
            if (_works.Exists(w => w.Equals(work)))
            {
                return false;
            }
            _works.Add(work);
            return true;
        }
        public bool Edit(int workCode, params object[] values)
        {
            Work work = GetWork(workCode);
            if (work == null)
            {
                return false;
            }
            if (work is Book)
            {
                return EditBook(workCode, (string)values[0], (string)values[1], (string)values[2]);
            }
            if (work is CD)
            {
                return EditCD(workCode, (string)values[0], (string)values[1], (int)values[2]);
            }
            return false;
        }
        public bool EditBook(int bookCode, string title, string authorName, string editorName)
        {
            Book book = GetBook(bookCode);
            if (book == null)
            {
                return false;
            }
            book.Title = title;
            book.AuthorName = authorName;
            book.EditorName = editorName;
            return true;
        }
        public bool EditCD(int cdCode, string title, string artistName, int trackCount)
        {
            CD cd = GetCD(cdCode);
            if (cd == null)
            {
                return false;
            }
            cd.Title = title;
            cd.ArtistName = artistName;
            cd.TrackCount = trackCount;
            return true;
        }
        public bool Delete(int workCode)
        {
            Work work = GetWork(workCode);
            if (work == null)
            {
                return false;
            }
            _works.Remove(work);
            return true;
        }

        // Save
        public string SaveToDataBase()
        {
            X.ADO.CommandedTable worksCTable = X.ADO.GetTable("select * from Work", "Work");
            X.ADO.CommandedTable booksCTable = X.ADO.GetTable("select * from Book", "Book");
            X.ADO.CommandedTable cdsCTable = X.ADO.GetTable("select * from CD", "CD");
            bool workNotFound = true;
            foreach (Work work in Works)
            {
                workNotFound = true;
                foreach (DataRow row in worksCTable.DataTable.Rows)
                {
                    if ((int)row["Code"] == work.Code)
                    {
                        workNotFound = false;
                        row["Title"] = work.Title;
                        row["State"] = work.State;
                        row["BorrowCount"] = work.BorrowCount;
                    }
                }
                if (workNotFound)
                {
                    worksCTable.DataTable.Rows.Add(work.Code, work.Title, work.State, work.BorrowCount);
                }
            }
            foreach (Book book in Books)
            {
                workNotFound = true;
                foreach (DataRow row in booksCTable.DataTable.Rows)
                {
                    if ((int)row["Code"] == book.Code)
                    {
                        workNotFound = false;
                        row["AuthorName"] = book.AuthorName;
                        row["EditorName"] = book.EditorName;
                    }
                }
                if (workNotFound)
                {
                    booksCTable.DataTable.Rows.Add(book.Code, book.AuthorName, book.EditorName);
                }
            }
            foreach (CD cd in CDs)
            {
                workNotFound = true;
                foreach (DataRow row in cdsCTable.DataTable.Rows)
                {
                    if ((int)row["Code"] == cd.Code)
                    {
                        workNotFound = false;
                        row["ArtistName"] = cd.ArtistName;
                        row["TrackCount"] = cd.TrackCount;
                    }
                }
                if (workNotFound)
                {
                    cdsCTable.DataTable.Rows.Add(cd.Code, cd.ArtistName, cd.TrackCount);
                }
            }
            foreach (DataRow row in worksCTable.DataTable.Rows)
            {
                if (GetWork((int)row["Code"]) == null)
                {
                    row.Delete();
                }
            }
            return string.Format
                ("{0} works ({1} books, {2} CDs) successfully saved.",
                    X.ADO.SetTable(worksCTable),
                    X.ADO.SetTable(booksCTable),
                    X.ADO.SetTable(cdsCTable)
                );
        }
        public int LoadFromDataBase()
        {
            X.ADO.CommandedTable worksCTable = X.ADO.GetTable("select * from Work", "Work");
            X.ADO.CommandedTable booksCTable = X.ADO.GetTable("select * from Book", "Book");
            X.ADO.CommandedTable cdsCTable = X.ADO.GetTable("select * from CD", "CD");
            if (worksCTable == null)
            {
                return 0;
            }
            else
            {
                foreach (DataRow row in booksCTable.DataTable.Rows)
                {
                    if (GetBook((int)row["Code"]) == null)
                    {
                        Works.Add(new Book("", (string)row["AuthorName"], (string)row["EditorName"]));
                    }
                }
                foreach (DataRow row in cdsCTable.DataTable.Rows)
                {
                    if (GetCD((int)row["Code"]) == null)
                    {
                        Works.Add(new CD("", (string)row["ArtistName"], (int)row["TrackCount"]));
                    }
                }
                foreach (DataRow row in worksCTable.DataTable.Rows)
                {
                    if (GetWork((int)row["Code"]) != null)
                    {
                        Works[worksCTable.DataTable.Rows.IndexOf(row)].Title = (string)row["Title"];
                    }
                }
                return worksCTable.DataTable.Rows.Count;
            }
        }
        public void ExportToFile(FileType fileType, string filePath)
        {
            switch (fileType)
            {
                case FileType.LIBRARY:
                    using (FileStream fileStream = File.OpenWrite(filePath))
                    {
                        BinaryFormatter binFormatter = new BinaryFormatter();
                        binFormatter.Serialize(fileStream, _works);
                    }
                    break; 
                case FileType.TXT:
                    using (StreamWriter streamWriter = new StreamWriter(filePath))
                    {
                        foreach (Work work in _works)
                        {
                            streamWriter.WriteLine(work.ToString());
                        }
                    }
                    break;
                case FileType.INI:
                    throw new NotImplementedException();
                    break;
                case FileType.XML:
                    using (StreamWriter streamWriter = new StreamWriter(filePath))
                    {
                        streamWriter.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        streamWriter.WriteLine("<Library>");
                        foreach (Work work in _works)
                        {
                            string workType = work.GetType().Name;
                            streamWriter.WriteLine("<Work Code=\"{0}\" Type=\"{1}\">", work.Code, workType);
                            streamWriter.WriteLine("<Title>{0}</Title>", work.Title);
                            streamWriter.WriteLine("<State>{0}</State>", work.State);
                            streamWriter.WriteLine("<BorrowCount>{0}</BorrowCount>", work.BorrowCount);
                            if (work is Book)
                            {
                                Book book = (Book)work;
                                streamWriter.WriteLine("<AuthorName>{0}</AuthorName>", book.AuthorName);
                                streamWriter.WriteLine("<EditorName>{0}</EditorName>", book.EditorName);
                            }
                            if (work is CD)
                            {
                                CD cd = (CD)work;
                                streamWriter.WriteLine("<ArtistName>{0}</ArtistName>", cd.ArtistName);
                                streamWriter.WriteLine("<TrackCount>{0}</TrackCount>", cd.TrackCount);
                            }
                            streamWriter.WriteLine("</Work>");
                        }
                        streamWriter.WriteLine("</Library>");
                    }
                    break;
                case FileType.JSON:
                    using (StreamWriter streamWriter = new StreamWriter(filePath))
                    {
                        streamWriter.WriteLine("{");
                        streamWriter.WriteLine("\"Library\": [");
                        foreach (Work work in _works)
                        {
                            streamWriter.WriteLine("{");
                            streamWriter.WriteLine("\"Code\": {0},", work.Code);
                            streamWriter.WriteLine("\"Type\": \"{0}\",", work.GetType().Name);
                            streamWriter.WriteLine("\"Title\": \"{0}\",", work.Title);
                            streamWriter.WriteLine("\"State\": {0},", work.State.ToString().ToLower());
                            streamWriter.WriteLine("\"BorrowCount\": {0},", work.BorrowCount);
                            if (work is Book)
                            {
                                Book book = (Book)work;
                                streamWriter.WriteLine("\"AuthorName>\": \"{0}\",", book.AuthorName);
                                streamWriter.WriteLine("\"EditorName\": \"{0}\"", book.EditorName);
                            }
                            if (work is CD)
                            {
                                CD cd = (CD)work;
                                streamWriter.WriteLine("\"ArtistName\": \"{0}\",", cd.ArtistName);
                                streamWriter.WriteLine("\"TrackCount\": {0}", cd.TrackCount);
                            }
                            streamWriter.WriteLine("}");
                            if (_works.IndexOf(work) != _works.Count - 1)
                            {
                                streamWriter.Write(",");
                            } 
                        }
                        streamWriter.WriteLine("]");
                        streamWriter.WriteLine("}");
                    }
                    break;
                default:
                    break;
            }
        }
        public void ImportFromFile(FileType fileType, string filePath)
        {
            switch (fileType)
            {
                case FileType.LIBRARY:
                    using (FileStream fileStream = File.OpenRead(filePath))
                    {
                        BinaryFormatter binFormatter = new BinaryFormatter();
                        _works = (List<Work>)binFormatter.Deserialize(fileStream);
                    }
                    break;
                case FileType.TXT:
                    using (StreamReader streamReader = new StreamReader(filePath))
                    {
                        /*  {Code}. {Title}. {StateDescription}. 
                         *  Borrowerd {BorrowCount} times. {WorkTypeName}. 
                         *  Written by / By {Author/ArtistName}. Edited by {EditorName}/ {TrackCount} tracks.
                        */
                        int parsedLinesCount = 0;
                        while (!streamReader.EndOfStream)
                        {
                            bool lineParsed = true;
                            string line = streamReader.ReadLine();
                            string[] extractedFields = line.Split('.');
                            if (extractedFields.Length >= 7)
                            {
                                int code = 0;
                                if (!int.TryParse(extractedFields[0], out code))
                                {
                                    lineParsed = false;
                                }
                                else
                                {
                                    string title = extractedFields[1];
                                    bool state = (extractedFields[2].ToLower() == "available") ? true : false;
                                    int borrowCount = 0;
                                    if (!int.TryParse(extractedFields[3], out borrowCount))
                                    {
                                        lineParsed = false;
                                    }
                                    else
                                    {
                                        string workTypeName = extractedFields[4];
                                        if (workTypeName == typeof(Book).Name)
                                        {
                                            string authorName = extractedFields[5];
                                            string editorName = extractedFields[6];
                                            Add(new Book(title, authorName, editorName));
                                        }
                                        else if (workTypeName == typeof(CD).Name)
                                        {
                                            string artistName = extractedFields[5];
                                            int trackCount = 0;
                                            if (!int.TryParse(extractedFields[6], out trackCount))
                                            {
                                                lineParsed = false;
                                            }
                                            Add(new CD(title, artistName, trackCount));
                                        }
                                        else
                                        {
                                            lineParsed = false;
                                        }
                                    }
                                }
                            }
                            if (lineParsed)
                            {
                                parsedLinesCount++;
                            }
                        }
                        if (parsedLinesCount == 0)
                        {
                            MessageBox.Show("Could not parse anything in the file.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (parsedLinesCount < File.ReadAllLines(filePath).Count())
                        {
                            MessageBox.Show("Could not entirely parse the file.\n{0} parsed out of {1} lines.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("File successfully parsed.\n{0} parsed out of {1} lines.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case FileType.INI:
                    throw new NotImplementedException();
                    break;
                case FileType.XML:
                    throw new NotImplementedException();
                    break;
                case FileType.JSON:
                    throw new NotImplementedException();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
