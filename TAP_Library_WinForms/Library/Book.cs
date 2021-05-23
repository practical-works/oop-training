using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    [Serializable]
    public class Book : Work
    {
        public string AuthorName { get; set; }
        public string EditorName { get; set; }

        public Book(string title, string authorName, string editorName) : base(title)
        {
            this.AuthorName = authorName;
            this.EditorName = editorName;
        }

        public override string Borrow()
        {
            base.Borrow();
            return string.Format("The book {0} is successfully borrowed.", this.Title);
        }
        public override string Return()
        {
            base.Return();
            return string.Format("The book {0} is successfully returned.", this.Title);
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Book. Written by {0}. Edited by {1}. ", 
                this.AuthorName, this.EditorName);
        }
    }
}
