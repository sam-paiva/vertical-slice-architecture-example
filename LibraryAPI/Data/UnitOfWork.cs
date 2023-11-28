using LibraryAPI.Data.Repositories;
using LibraryAPI.Domain.Interfaces;

namespace LibraryAPI.Data;

public sealed class UnitOfWork : IUnitOfWork
{
    private IBooksRepository? _booksService;
    private readonly DataContext _dataContext;

    public UnitOfWork(DataContext context)
    {
        _dataContext = context;
    }
    
    public IBooksRepository Books
    {
        get { return _booksService ??= new BooksRepository(_dataContext); }
    }

    public Task SaveAsync()
    {
        return _dataContext.SaveChangesAsync();
    }
}