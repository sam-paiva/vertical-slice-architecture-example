namespace LibraryAPI.Domain.Interfaces;

public interface IBooksRepository
{
    Task<Book> GetBookByIdAsync(Guid id);
    Task<List<Book>> GetAllBooksAsync();
    Task AddBookAsync(Book book);
    Task DeleteBookAsync(Book book);
}