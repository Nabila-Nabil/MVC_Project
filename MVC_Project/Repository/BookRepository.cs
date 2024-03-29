﻿using MVC_Project.Interfaces;

namespace MVC_Project.Repository
{
    public class BookRepository:IBook
    {
        BookStoreContext bookStoreContext;
        public BookRepository(BookStoreContext _bookStoreContext)
        {
            bookStoreContext = _bookStoreContext;
        }


        public List<Book> GetAllBooks()
        {
            List<Book> books = bookStoreContext.Books.ToList();
            return books;
        }
        public Book GetBookById(int id)
        {
            Book book = bookStoreContext.Books.FirstOrDefault(b => b.BookId == id);
            return book;
        }
        public void InsertBook(Book book)
        {
            bookStoreContext.Books.Add(book);
        }
        public void UpdateBook(int id)
        {
            Book book = bookStoreContext.Books.FirstOrDefault(b => b.BookId == id);
            bookStoreContext.Books.Update(book);
        }
        public void DeleteBook(int id)
        {
            Book book = bookStoreContext.Books.FirstOrDefault(b => b.BookId == id);
            bookStoreContext.Books.Remove(book);
        }
        public Author GetBookAuthor(string name)
        {
            Author author = bookStoreContext.Authors.FirstOrDefault(a => a.AuthorName == name);
            return author;
        }
        public void Save()
        {
            bookStoreContext.SaveChanges();
        }

    }
}