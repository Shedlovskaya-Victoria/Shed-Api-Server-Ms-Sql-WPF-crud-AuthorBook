using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;
using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO;
using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.Service;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookCRUD bookCRUD;
        private User02Context context;

        public BooksController(BookCRUD bookCRUD, User02Context user02Context)
        {
            this.bookCRUD = bookCRUD;
            this.context = user02Context;
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] BookServerDTO bookServerDTO)
        {
            bookCRUD.Add((BookShedBd)bookServerDTO);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BookServerDTO>>> Get()
        {
            if (context.BookShedBds == null)
                return NotFound();

            return await context.BookShedBds.Select(x => new BookServerDTO
            {
                Id = x.Id,
                Title = x.Title,
                GanreServer = new GanreServerDTO
                {
                    Id = x.IdGenreNavigation.Id,
                    Name = x.IdGenreNavigation.Name,
                },
                IdGenre = x.IdGenre
            }).ToListAsync();
        }
        [HttpPost("GetById")]
        public async Task<ActionResult<BookServerDTO>> GetById([FromBody] int id)
        {
            if (context.BookShedBds == null)
                return NotFound();

            return (BookServerDTO)await context.BookShedBds.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost("Delete")]
        public ActionResult DeleteById([FromBody] BookServerDTO bookServerDTO)
        {
            if (context.BookShedBds == null)
                return NotFound();

            bookCRUD.Delete((BookShedBd)bookServerDTO);

            return Ok();
        }
        [HttpPost("Edit")]
        public ActionResult EditById([FromBody] BookServerDTO bookServerDTO)
        {
            if (context.BookShedBds == null)
                return NotFound();

            bookCRUD.Edit((BookShedBd)bookServerDTO);

            return Ok();
        }
    }
}
