using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.BookManager
{
    public class BookManager : IBookManager
    {
        public List<LibraryManager.Book.Book> Books = new List<LibraryManager.Book.Book>();

        public void CreateBook(string Title, string Author)
        {
            Books.Add(new LibraryManager.Book.Book() {Title= Title  ,Author = Author });
        }

        public void DeleteBook(string Title)
        {
            var Book =  Books.Find(x => x.Title == Title);
            Books.Remove(Book);

        }

        public Book.Book FindBook(string Title)
        {
            return Books.Find(x => x.Title == Title);
        }

        public List<Book.Book> OutputBooks()
        {

            return Books;
        }
    }
}
