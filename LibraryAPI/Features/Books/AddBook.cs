using LibraryAPI.Domain;
using LibraryAPI.Domain.Interfaces;
using MediatR;

namespace LibraryAPI.Features.Books;

public class AddBook
{
    public record AddBookCommand : IRequest<Guid>
    {
        public string? BookName { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }

    public sealed class AddBookCommandHandler : IRequestHandler<AddBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.BookName!, request.Author!, request.Price);
            await _unitOfWork.Books.AddBookAsync(book);
            await _unitOfWork.SaveAsync();

            return book.Id;
        }
    }
}