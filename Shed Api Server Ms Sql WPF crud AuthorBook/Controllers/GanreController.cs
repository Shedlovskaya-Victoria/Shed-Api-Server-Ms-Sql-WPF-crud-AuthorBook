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
    public class GanreController : ControllerBase
    {
        public GanreCRUD ganreCRUD;
        private readonly User02Context context;

        public GanreController(GanreCRUD ganreCRUD, User02Context context)
        {
            this.ganreCRUD = ganreCRUD;
            this.context = context;
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] GanreServerDTO ganreServerDTO)
        {
            ganreCRUD.Add(new GenreShedBd 
            { 
                Id = ganreServerDTO.Id, 
                Name = ganreServerDTO.Name 
            });
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GanreServerDTO>>> Get()
        {
            if (context.GenreShedBds == null)
                return NotFound();

            return await context.GenreShedBds.Select(x => new GanreServerDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }
        [HttpPost("GetById")]
        public async Task<ActionResult<GanreServerDTO>> GetById([FromBody] int id)
        {
            if (context.GenreShedBds == null)
                return NotFound();

            return (GanreServerDTO)await context.GenreShedBds.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost("Delete")]
        public ActionResult DeleteById([FromBody] GanreServerDTO ganreServerDTO)
        {
            if (context.GenreShedBds == null)
                return NotFound();

            ganreCRUD.Delete(new GenreShedBd
            {
                Id = ganreServerDTO.Id,
                Name = ganreServerDTO.Name
            });

            return Ok();
        }
        [HttpPost("Edit")]
        public ActionResult EditById([FromBody] GanreServerDTO ganreServerDTO)
        {
            if (context.GenreShedBds == null)
                return NotFound();

            ganreCRUD.Edit(new GenreShedBd
            {
                Id =ganreServerDTO.Id,
                Name =ganreServerDTO.Name
            });

            return Ok();
        }
    }
}
