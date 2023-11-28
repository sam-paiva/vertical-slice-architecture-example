using LibraryAPI.Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace LibraryAPI.Features.Books;

public class GetAllBooks
{
    public record GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
    {
        
    }

    public record BookDto
    {
        public Guid Id { get; set; }
        public required string AuthorName { get; set; }
        public required string Name { get; set; }
    }
    
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _unitOfWork.Books.GetAllBooksAsync();
            return _mapper.From(books).AdaptToType<IEnumerable<BookDto>>();
        }
    }
}