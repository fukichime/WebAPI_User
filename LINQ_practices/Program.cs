using System;
using System.Collections.Generic;
using System.Linq;
  
        List<Book> books = new List<Book>
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

        
        //Filtering books by author
        var poeBooks = from book in books
                       where book.Author == "Edgar Allan Poe"
                       select book;

        Console.WriteLine("Books by Edgar Allan Poe:");
        PrintBooks(poeBooks);

        // Ordering books by publish year
        var orderedBooks = books.OrderBy(book => book.PublishYear);

        Console.WriteLine("\nBooks ordered by Publish Year:");
        PrintBooks(orderedBooks);

        //Projecting book titles and authors
        var bookTitlesAndAuthors = from book in books
                                   select new { book.Title, book.Author };

        Console.WriteLine("\nBook Titles and Authors:");
        foreach (var titleAuthor in bookTitlesAndAuthors)
        {
            Console.WriteLine($"{titleAuthor.Title} by {titleAuthor.Author}");
        }

       // Counting the number of books in each genre
       var genreCounts = books.GroupBy(book => book.Genre)
                         .Select(group => new { Genre = group.Key, Count = group.Count() });

            Console.WriteLine("\nNumber of Books in Each Genre:");
       foreach (var genreCount in genreCounts)
       {
           Console.WriteLine($"{genreCount.Genre}: {genreCount.Count}");
       }



Console.ReadLine();
  

    static void PrintBooks(IEnumerable<Book> bookList)
    {
        foreach (var book in bookList)
        {
            Console.WriteLine($"{book.Title} by {book.Author} ({book.PublishYear})");
        }
    }

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishYear { get; set; }
    public int PageCount { get; set; }
    public string Genre { get; set; }
}

