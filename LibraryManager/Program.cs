using System.Diagnostics;

namespace LibraryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            bool infiti = true;
            Trace.WriteLine($"[LOG] {DateTime.Now} Программа запущена.");
            LibraryManager.BookManager.BookManager BookManager = new LibraryManager.BookManager.BookManager();

            while (infiti)
            {
                try
                {


                    Trace.WriteLine("Видите  команды (для проверки):\r\n");
                    Trace.WriteLine("add");
                    Trace.WriteLine("list");
                    Trace.WriteLine("remove");
                    Trace.WriteLine("search");
                    Trace.WriteLine("finish");
                    string command = Console.ReadLine();
                    string TitleBook = "";
                    switch (command)
                    {
                        case "add":

                            Console.WriteLine("\"Введите название книги: 1984\r\n\"");


                            TitleBook = Console.ReadLine();
                            Console.WriteLine($"Введите автора книги: Джордж Оруэлл\r\n");

                            var AuthorBook = Console.ReadLine();


                            Trace.WriteLine($"[TRACE] {DateTime.Now} Попытка добавить книгу: \"{TitleBook}\" — {AuthorBook}");
                            BookManager.CreateBook(TitleBook, AuthorBook);


                            Trace.WriteLine($"[LOG]  {DateTime.Now} Добавлена книга: \"{TitleBook}\" — {AuthorBook}");
                            break;
                        case "list":
                            var Books = BookManager.OutputBooks();
                            Trace.WriteLine($"[TRACE] {DateTime.Now} Вывод всех книг в коллекции.");

                            if (Books != null)
                            {
                                if (Books.Count() > 0)
                                {
                                    Trace.WriteLine($"{DateTime.Now} Количество книг:{Books.Count}");

                                    foreach (var books in Books)
                                    {
                                        Trace.WriteLine($"{DateTime.Now} Количество книг:{books.title} {books.author}");

                                    }

                                }
                                else
                                {
                                    Trace.WriteLine($"{DateTime.Now} Количество книг:{0}");

                                }
                            }
                            break;
                        case "remove":
                            Trace.WriteLine("Введите название книги для удаления: 1984\r\n");
                            TitleBook = Console.ReadLine();
                            BookManager.DeleteBook(TitleBook);

                            Trace.WriteLine($"[TRACE] {DateTime.Now} Попытка удалить книгу: \"{1984}\".");


                            Trace.WriteLine($"[LOG] {DateTime.Now} Книга \"{1984}\" удалена.");
                            break;
                        case "search":

                            Trace.WriteLine("Введите название книги для поиска: Мастер и Маргарита");
                            TitleBook = Console.ReadLine();


                            Trace.WriteLine($"[TRACE] {DateTime.Now} Попытка поиска книги: \"Мастер и Маргарита\".");
                            var Book = BookManager.FindBook(TitleBook);
                            if (Book == null)
                            {
                                Trace.WriteLine($"[LOG] {DateTime.Now}  Книга \"Мастер и Маргарит не найдена.");
                            }
                            break;
                        case "finish":
                            infiti = false;
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Trace.WriteLine($"Ошибка: {ex.Message}");
                    Trace.WriteLine("Стек вызовов:");
                    Trace.WriteLine(ex.StackTrace); // Трассировка ошибки
                }
            }

            Console.ReadLine();
        }
    }
}
