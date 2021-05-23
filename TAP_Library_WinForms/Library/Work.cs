using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    [Serializable]
    public abstract class Work
    {
        public int Code { get; protected set; }
        public static int Count { get; protected set; }
        public string Title { get; set; }
        public bool State { get; set; }
        public int BorrowCount { get; protected set; }

        static Work()
        {
            Work.Count = 0;
        }

        public Work(string title)
        {
            Work.Count++;
            this.Code = Work.Count;
            this.Title = title;
            this.State = true;
            this.BorrowCount = 0;
        }

        public virtual string Borrow()
        {
            this.BorrowCount++;
            this.State = false;
            return string.Format("The work {0} is successfully borrowed.", this.Title);
        }
        public virtual string Return()
        {
            this.State = true;
            return string.Format("The work {0} is successfully returned.", this.Title);
        }

        public override string ToString()
        {
            string availability = this.State ? "Available" : "Not available";
            return string.Format("{0}. {1}. {2}. Borrowerd {3} times. ", 
                this.Code, this.Title, availability, this.BorrowCount);
        }
    }
}
