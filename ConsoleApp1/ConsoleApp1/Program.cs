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
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!File.Exists(file))
               File.Create(file);
            Library library = new Library();
            library.LibId = 1;
            library.Name = "Baki Book Center";
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
                        Book book = new Book();
                        int id;
                        string idStr;
                        do
                        {
                            Console.Write("Kitabin Id daxil edin: ");
                            idStr = Console.ReadLine();
                        } while (!int.TryParse(idStr,out id));
                        id = Convert.ToInt32(idStr);
                        book.Id = id;
                        Console.Write("Kitabin adi: ");
                        book.Name = Console.ReadLine();
                        Console.Write("Kitabin muellifi: ");
                        book.AuthorName = Console.ReadLine();
                        
                        double price;
                        string priceStr; 
                        do
                        {
                            Console.Write("Kitabin qiymeti: ");
                            priceStr = Console.ReadLine();
                        } while (!double.TryParse(priceStr,out price));
                        price = Convert.ToDouble(priceStr);
                        book.Price = price;
                        library.AddBook(book);
                        string convert = JsonConvert.SerializeObject(library);
                        using (StreamWriter sr = new StreamWriter(file))
                        {
                            sr.Write(convert);
                        }
                        break;
                    case "2":
                        string result;
                        using (StreamReader sr = new StreamReader(file))
                        {
                            result = sr.ReadToEnd();
                        }
                        library = JsonConvert.DeserializeObject<Library>(result);
                        Console.Write("Axdarilacaq kitabin Id daxil edin: ");
                        int wantedId;
                        string wantedIdStr;
                        do
                        {
                            wantedIdStr = Console.ReadLine();
                        } while (!int.TryParse(wantedIdStr, out wantedId));
                        wantedId = Convert.ToInt32(wantedIdStr);
                        Console.WriteLine(library.GetBookById(wantedId).ShowInfo());
                        break;
                    case "3":
                        string removeResult;
                        using (StreamReader sr = new StreamReader(file))
                        {
                            removeResult = sr.ReadToEnd();
                        }
                        library = JsonConvert.DeserializeObject<Library>(removeResult);
                        Console.Write("Silinecek kitabin Id daxil edin: ");
                        int removedId;
                        string removedidStr;
                        do
                        {
                            removedidStr = Console.ReadLine();
                        } while (!int.TryParse(removedidStr, out removedId));
                        removedId = Convert.ToInt32(removedidStr);
                        library.RemoveBook(removedId);
                        string newLibraryStr = JsonConvert.SerializeObject(library);
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
