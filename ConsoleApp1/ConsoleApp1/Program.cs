using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = @"C:\Users\ELNUR\Desktop\Home Task\Home Task19\ConsoleApp1\ConsoleApp1\Files\";
            string file = @"C:\Users\ELNUR\Desktop\Home Task\Home Task19\ConsoleApp1\ConsoleApp1\Files\database.json";
                Directory.CreateDirectory(path);
            if (!File.Exists(file))
            {
               File.Create(file);
            }
                
            Library library = new Library();
            bool exit = false;
            do
            {
                Console.WriteLine("1. Add book\n2. Get book by id\n3. Remove book\n0. Quit");
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        Console.Write("Kitabin adi: ");
                        Book book = new Book();
                        book.Name = Console.ReadLine();
                        Console.Write("Kitabin muellifi: ");
                        book.AuthorName = Console.ReadLine();
                        Console.Write("Kitabin qiymeti: ");
                        double price;
                        string priceStr; 
                        do
                        {
                            priceStr = Console.ReadLine();
                        } while (!double.TryParse(priceStr,out price));
                        price = Convert.ToDouble(priceStr);
                        book.Price = price;
                        library.AddBook(book);
                        string convert = JsonConvert.SerializeObject(book);
                        using (StreamWriter sr = new StreamWriter(file))
                        {
                            sr.WriteLine(convert);
                        }
                        break;
                    case "2":
                        string result;
                        using (StreamReader sr = new StreamReader(file))
                        {
                            result = sr.ReadToEnd();
                        }
                        Library newLibrary = JsonConvert.DeserializeObject<Library>(result);
                        Console.WriteLine("Axdarilacaq kitabin Id daxil edin: ");
                        int id;
                        string idStr;
                        do
                        {
                            idStr = Console.ReadLine();
                        } while (!int.TryParse(idStr,out id));
                        id = Convert.ToInt32(idStr);
                        Console.WriteLine(newLibrary.GetBookById(id).ShowInfo()); 
                    break;
                    case "3":
                        string removeResult;
                        using (StreamReader sr = new StreamReader(file))
                        {
                            removeResult = sr.ReadToEnd();
                        }
                        newLibrary = JsonConvert.DeserializeObject<Library>(removeResult);
                        Console.WriteLine("Silinecek kitabin Id daxil edin: ");
                        int removedId;
                        string removedidStr;
                        do
                        {
                            removedidStr = Console.ReadLine();
                        } while (!int.TryParse(removedidStr, out removedId));
                        removedId = Convert.ToInt32(removedidStr);
                        newLibrary.RemoveBook(removedId);
                        string newLibraryStr = JsonConvert.SerializeObject(newLibrary);
                        using(StreamWriter sr = new StreamWriter(file))
                        {
                            sr.WriteLine(newLibraryStr);
                        }
                        break;
                    default:
                        break;
                }
            } while (!exit);
        }
    }
}
