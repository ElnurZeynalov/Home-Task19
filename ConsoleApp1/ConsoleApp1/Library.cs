using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Library
    {
        private static int _libId;
        public int LibId { get; }
        public string Name { get; set; }
        private List<Book> _books { get; set; } = new List<Book>();
        public Library()
        {
            _libId++;
            LibId = _libId;
        }
        public void AddBook(Book book)
        {
            _books.Add(book);
        }
        public Book GetBookById(int? id)
        {
            if (id == null)
                throw new NullReferenceException();
            Book book = _books.Find(x => x.Id == id);
            if (book == null)
                throw new NullReferenceException();
                
            return book;
        }
        public void RemoveBook(int? id)
        {
            if (id == null)
                throw new NullReferenceException();
            Book book = _books.Find(x => x.Id == id);
            if (book == null)
                throw new NullReferenceException();
           _books.Remove(book);
        }
    }
}
