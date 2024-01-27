
using System.ComponentModel.DataAnnotations;
using HowToNotCode;


try
{
    IBookRepository bookRepository = new BookRepository();
    BookService bookService = new BookService(bookRepository);

    bookService.ViewBooksAndAuthors();

    Console.ReadLine();

    Console.WriteLine("\nChoose a book to delete with  its title:");
    string titleToDelete = Console.ReadLine();

    bookService.DeleteBook(titleToDelete);

}
catch (ValidationException ex)
{
    ExceptionHandler.HandleValidationException(ex);
}
catch (Exception ex)
{
    ExceptionHandler.HandleException(ex);
}
