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
    public class AuthorsController : ControllerBase
    {
        public AuthorCRUD authorCRUD;
        private readonly User02Context context;

        public AuthorsController(AuthorCRUD authorCRUD, User02Context context)
        {
            this.authorCRUD = authorCRUD;
            this.context = context;
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] AuthorServerDTO authorServerDTO)
        {
            authorCRUD.Add((GanreShedBd)authorServerDTO);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<AuthorServerDTO>>> Get()
        {
            if (context.AuthorShedBds == null)
                return NotFound();

            return await context.AuthorShedBds.Select(x => new AuthorServerDTO
            {
                Id = x.Id,
                Age = x.Age,
                Experience = x.Experience,
                Fio = x.Fio
            }).ToListAsync();
        }
        [HttpPost("GetById")]
        public async Task<ActionResult<AuthorServerDTO>> GetById([FromBody] int id)
        {
            if(context.AuthorShedBds == null) 
                return NotFound();

            return (AuthorServerDTO)await context.AuthorShedBds.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost("Delete")]
        public ActionResult DeleteById([FromBody] AuthorServerDTO authorServerDTO)
        {
            if (context.AuthorShedBds == null)
                return NotFound();

            authorCRUD.Delete((GanreShedBd)authorServerDTO);

            return Ok();
        }
        [HttpPost("Edit")]
        public ActionResult EditById([FromBody] AuthorServerDTO authorServerDTO)
        {
            if (context.AuthorShedBds == null)
                return NotFound();

            authorCRUD.Edit((GanreShedBd)authorServerDTO);

            return Ok();
        }
    }
}
