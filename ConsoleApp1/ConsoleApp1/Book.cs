using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Book
    {
        private static int _id;
        public int Id { get;}
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }
        public string ShowInfo()
        {
            return $"Id: {Id}Name: {Name}AuthorName: {AuthorName}Price: {Price}";
        }
        public Book()
        {
            _id++;
            Id = _id;
        }
    }
}
