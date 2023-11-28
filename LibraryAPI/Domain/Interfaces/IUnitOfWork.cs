namespace LibraryAPI.Domain.Interfaces;

public interface IUnitOfWork
{
    IBooksRepository Books { get; }
    Task SaveAsync();
}