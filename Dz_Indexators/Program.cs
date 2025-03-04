﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_Indexators
{
    class Book
    {
        public string Author { get; set; }
        public string NameBook { get; set; }
        public string Genre { get; set; }
        private int pages {  get; set; }
        public int Pages 
        {
            get { return pages; }
            
            set
            {
                if (value >= 0)
                {
                    pages = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect pages!");
                }
            }
        }
        public Book(string author, string nameBook, string genre, int pages)
        {
            Author = author;
            NameBook = nameBook;
            Genre = genre;
            Pages = pages;
        }
        public void Print()
        {
            Console.WriteLine($"Author : {Author}, title : {NameBook}, genre : {Genre}, pages : {Pages}");
        }

    }
   class BookList
    {
        private Book[] books;
        private List<Book> booksList;

        public BookList(int size) 
        { 
            books = new Book[size];
            booksList = new List<Book>(size);
        }
        public void AddBook(Book book)
        {
            booksList.Add(book);
        }
        public void RemoveBook(Book book) {
            booksList.Remove(book);
        }
        public bool ContainsBook(Book book)
        {
            return booksList.Contains(book);
        }

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Length)
                {
                    return books[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < books.Length)
                {
                    books[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public Book this[string name]
        {
            get
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].NameBook == name)
                    {
                        return books[i];
                    }
                }
                return null;
            }
        }
        public int Length => books.Length;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BookList myBookList = new BookList(10);

            myBookList.AddBook(new Book("Тарас Шевченко", "Кобзар", "Поезія", 115));
            myBookList.AddBook(new Book("Джордж Орвелл", "1984", "Роман-антиутопія", 312));
            myBookList.AddBook(new Book("Валер'ян Підмогильний", "Місто", "Урбаністичний роман", 238));

            Console.WriteLine($"Is '1984' in the list? " + myBookList.ContainsBook(new Book("", "1984", "", 0)));
            myBookList.RemoveBook(new Book("", "1984", "", 312));
            Console.WriteLine("Number of books in the list: " + myBookList.Length);
            Console.WriteLine("First book in the list: ");
            myBookList[0].Print();
        }
    }
}
