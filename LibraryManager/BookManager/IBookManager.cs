using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.BookManager
{
    public interface IBookManager
    {
        void CreateBook(string Title,string Author);
        void DeleteBook(string Title);

        Book.Book FindBook(string Title);

        List<Book.Book> OutputBooks();
    }
}
