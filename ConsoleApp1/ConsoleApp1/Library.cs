using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Library
    {
        public int LibId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public Book GetBookById(int? id)
        {
            if (id == null)
                throw new NullReferenceException();
            var book = Books.Find(x => x.Id == id);
            if (book == null)
                throw new NullReferenceException();
                
            return book;
        }
        public void RemoveBook(int? id)
        {
            if (id == null)
                throw new NullReferenceException();
            Book book = Books.Find(x => x.Id == id);
            if (book == null)
                throw new NullReferenceException();
           Books.Remove(book);
        }
        public List<Book> GetAllBook()
        {
            return Books;
        }
    }
}
