
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Book
{
    public class Book : IBook
    {
        public string title;
        public string author;

        public override string Title { get => title; set => title =value; }
        public override string Author { get => author; set => author =value; }
    }
}

