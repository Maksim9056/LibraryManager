using System.Diagnostics;
using System.Security;

namespace LibraryManager
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.Listeners.Add(new ConsoleTraceListener());

            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));

            //PerformanceCounter performanceCounter = new PerformanceCounter();
            //performanceCounter.
            Trace.WriteLine($"[LOG] {DateTime.Now} Программа запущена.");


            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            Trace.WriteLine("Текущая загрузка CPU: " + cpuCounter.NextValue() + " %");
            System.Threading.Thread.Sleep(1000); // Даем время для сбора данных
            Trace.WriteLine("Загрузка CPU через секунду: " + cpuCounter.NextValue() + " %");


            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                if (!EventLog.SourceExists("LibraryManager"))
                {
                    EventLog.CreateEventSource("LibraryManager", "Application");
                }
                EventLog.WriteEntry("LibraryManager", "Это сообщение записано в журнале EventLog", EventLogEntryType.Information);
                Process process = Process.Start("notepad.exe");
                EventLog.WriteEntry("LibraryManager", "Блокнот запущен Information", EventLogEntryType.Information);

                process.WaitForExit();
                EventLog.WriteEntry("LibraryManager", "Блокнот закрыт Warning", EventLogEntryType.Warning);
                //EventLog.WriteEntry("LibraryManager", "Блокнот закрыт FailureAudit", EventLogEntryType.FailureAudit);
                //EventLog.WriteEntry("LibraryManager", "Блокнот закрыт SuccessAudit", EventLogEntryType.SuccessAudit);

                EventLog.WriteEntry("LibraryManager", "Блокнот закрыт Error", EventLogEntryType.Error);
                stopwatch.Stop();
                EventLog.WriteEntry("LibraryManager", $"Операция заняла {stopwatch.ElapsedMilliseconds} мс", EventLogEntryType.Information);


            }
            catch (SecurityException ex)
            {
                Console.WriteLine($"Ошибка безопасности: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }


            bool infiti = true;
            LibraryManager.BookManager.BookManager BookManager = new LibraryManager.BookManager.BookManager();

            while (infiti)
            {
                try
                {
                    
                    TraceSource traceSource = new TraceSource("LibraryManager");


                    traceSource.Listeners.Add(new ConsoleTraceListener());

                    traceSource.TraceInformation("");
                    traceSource.TraceEvent(TraceEventType.Warning, 1, "Это предупреждение");

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

            Trace.Flush();
            Trace.Close();

            Console.ReadLine();
        }
    }
}
