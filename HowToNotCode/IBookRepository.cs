using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToNotCode
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookByTitle(string title);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(string title);
    }
}
