using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace HowToNotCode
{
    public class BookService
    {
        // Bad example of interface implementation(example for dependency inversion)
        #region BadCodeDIP
        //private readonly InMemoryBookRepository bookRepository;

        //public BadBookService()
        //{
        //    bookRepository = new InMemoryBookRepository();
        //} 
        #endregion

        //Good example
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }

        //Bad example to add a new book => all logics are mixed with each other
        #region Bad-Code
        //public void AddBook(string title, string author, int publishYear, int pageCount, string genre)
        //{
        //    if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        //    {
        //        Console.WriteLine("Title and Author are required.");
        //        return;
        //    }

        //    var newBook = new Book
        //    {
        //        Title = title,
        //        Author = author,
        //        PublishYear = publishYear,
        //        PageCount = pageCount,
        //        Genre = genre
        //    };

        //    bookRepository.AddBook(newBook);

        //    Console.WriteLine($"Book '{title}' added successfully.");
        //}
        #endregion

        //Good example => logics are separated
        public void AddBook(Book newBook)
        {
            if (!IsValidBook(newBook))
            {
                Console.WriteLine("Invalid book data. Title and Author are required.");
                return;
            }
            bookRepository.AddBook(newBook);

            Console.WriteLine($"Book '{newBook.Title}' added successfully.");
        }

        private bool IsValidBook(Book book)
        {
            return !string.IsNullOrWhiteSpace(book.Title) && !string.IsNullOrWhiteSpace(book.Author);
        }

        public void UpdateBook(Book updatedBook)
        {
            bookRepository.UpdateBook(updatedBook);
        }


        //good example
        public void DeleteBook(string title)
        {
            bookRepository.DeleteBook(title);
        }

        //bad example for displaying books
        #region Badcodefordisplay
        //public void ViewBooksAndAuthors()
        //{
        //    var books = bookRepository.GetAllBooks();
        //    foreach (var book in books)
        //    {
        //        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        //    }
        //} 
        #endregion

        //good example - separating tasks and giving them better UI view
        public void ViewBooksAndAuthors()
        {
            var books = bookRepository.GetAllBooks();
            DisplayBooksAndAuthors(books);
        }

        private void DisplayBooksAndAuthors(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
        }

    }
}
