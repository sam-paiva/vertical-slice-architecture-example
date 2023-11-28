using LibraryAPI.Domain;
using LibraryAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data.Repositories;

public sealed class BooksRepository : IBooksRepository
{
    private readonly DataContext _dataContext;

    public BooksRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task<Book> GetBookByIdAsync(Guid id)
    {
        return _dataContext.Books!.SingleAsync(c => c.Id.Equals(id));
    }

    public Task<List<Book>> GetAllBooksAsync()
    {
        return _dataContext.Books!.ToListAsync();
    }

    public async Task AddBookAsync(Book book)
    {
        await _dataContext.Books!.AddAsync(book);
    }

    public Task DeleteBookAsync(Book book)
    {
        return Task.FromResult(_dataContext.Books!.Remove(book));
    }
}