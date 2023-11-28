using LibraryAPI.Features.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Guid;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var data = await _mediator.Send(new GetAllBooks.GetAllBooksQuery());

            return Ok(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBook.AddBookCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);

                return CreatedAtAction(nameof(AddBook), result);
            }
            catch (Exception e)
            {
                return Problem(
                    detail: "Error when trying to Add book",
                    title: e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            try
            {
                TryParse(id, out Guid bookId);
            
                await _mediator.Send(new DeleteBook.DeleteBookCommand()
                {
                    Id = bookId
                });

                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(
                    detail: "Error when trying to delete book",
                    title: e.Message);
            }
        }
    }
}
