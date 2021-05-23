using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    [Serializable]
    public class CD : Work
    {
        public string ArtistName { get; set; }
        public int TrackCount { get; set; }

        public CD(string title, string artistName, int trackCount) : base(title)
        {
            this.ArtistName = artistName;
            this.TrackCount = trackCount;
        }

        public override string Borrow()
        {
            base.Borrow();
            return string.Format("The CD {0} is successfully borrowed.", this.Title);
        }
        public override string Return()
        {
            base.Return();
            return string.Format("The CD {0} is successfully returned.", this.Title);
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("CD. By {1}. {0} tracks.",
                this.TrackCount, this.ArtistName);
        }
    }
}
