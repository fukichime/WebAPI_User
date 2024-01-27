using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToNotCode
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books;

        public BookRepository()
        {
            
            books = new List<Book>
        {
            new Book { Title = "The Raven", Author = "Edgar Allan Poe", PublishYear = 1845, PageCount = 48, Genre = "Poetry" },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", PublishYear = 1813, PageCount = 432, Genre = "Fiction" },
            new Book { Title = "War and Peace", Author = "Leo Tolstoy", PublishYear = 1869, PageCount = 1225, Genre = "Historical Fiction" },
            new Book { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", PublishYear = 1866, PageCount = 671, Genre = "Philosophical Fiction" },
            new Book { Title = "The Tell-Tale Heart", Author = "Edgar Allan Poe", PublishYear = 1843, PageCount = 20, Genre = "Short Story" },
            new Book { Title = "The Fall of the House of Usher", Author = "Edgar Allan Poe", PublishYear = 1839, PageCount = 64, Genre = "Gothic Fiction" },
            new Book { Title = "Sense and Sensibility", Author = "Jane Austen", PublishYear = 1811, PageCount = 352, Genre = "Fiction" },
            new Book { Title = "Annabel Lee", Author = "Edgar Allan Poe", PublishYear = 1849, PageCount = 30, Genre = "Poetry" }
        };
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookByTitle(string title)
        {
            return books.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void UpdateBook(Book updatedBook)
        {
            var existingBook = GetBookByTitle(updatedBook.Title);
            if (existingBook != null)
            {
                existingBook.Author = updatedBook.Author;
                existingBook.PublishYear = updatedBook.PublishYear;
                existingBook.PageCount = updatedBook.PageCount;
                existingBook.Genre = updatedBook.Genre;
            }
        }

        //bad example for exception => too much responsibilty, limited use, violates OCP because of console output
        #region BadcodeEx
        //public void DeleteBook(string title)
        //{
        //    try
        //    {
        //        var bookToRemove = GetBookByTitle(title);
        //        if (bookToRemove != null)
        //        {
        //            books.Remove(bookToRemove);
        //            Console.WriteLine($"Book '{title}' removed successfully.");
        //        }
        //    }
        //    catch (ValidationException ex)
        //    {
        //        Console.WriteLine($"Validation error: {ex.Message}");
        //        // Log the exception or perform additional validation error handling tasks
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        // Log the exception or perform additional error handling tasks
        //    }
        //} 
        #endregion

        //ideally it would be better to put the exceptions to all methods but demonstration it's in delete method
        //however better way would be to make decentralized rather than local handling
        //good example
        public void DeleteBook(string title)
        {
            try
            {
                var bookToRemove = GetBookByTitle(title);
                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    
    }

}
