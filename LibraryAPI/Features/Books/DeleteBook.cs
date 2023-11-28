using LibraryAPI.Domain.Interfaces;
using MediatR;

namespace LibraryAPI.Features.Books;

public abstract class DeleteBook
{
    public sealed record DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }
    
    public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetBookByIdAsync(request.Id);
            await _unitOfWork.Books.DeleteBookAsync(book);
            await _unitOfWork.SaveAsync();
        }
    }
}