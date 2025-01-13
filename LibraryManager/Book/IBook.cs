using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Book
{
    public   abstract class IBook
    {
        public abstract string Title { get; set; }
        public abstract  string Author { get; set; }


    }
}
