using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoS
{
    public class CustomComment
    {
        public string title;
        public string comment;
        public string referenceURL;

        public CustomComment(): this("", "", "") {}

        public CustomComment(string title, string comment, string referenceURL)
        {
            this.title = title;
            this.comment = comment;
            this.referenceURL = referenceURL;
        }
    }
}
