using System.Collections.ObjectModel;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO
{
    public partial class BookServerDTO
    {

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int IdGenre { get; set; }

        public string? Description { get; set; }
        public GanreServerDTO GanreServer { get; set; } = new GanreServerDTO();

        public static explicit operator BookServerDTO(
            Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.BookShedBd bookShedBd) => new BookServerDTO
            {
                Id = bookShedBd.Id,
                Description = bookShedBd.Description,
                Title = bookShedBd.Title,
                IdGenre = bookShedBd.IdGenre,
                GanreServer = new GanreServerDTO
                {
                    Id = bookShedBd.IdGenreNavigation.Id,
                    Name = bookShedBd.IdGenreNavigation.Name,
                }
            };
        public static explicit operator BookShedBd(
            Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO.BookServerDTO bookServerDTO) => new BookShedBd
            {
                Id = bookServerDTO.Id,
                Description = bookServerDTO.Description,
                Title = bookServerDTO.Title,
                IdGenre = bookServerDTO.IdGenre,
                IdGenreNavigation = new GenreShedBd
                {
                    Id = bookServerDTO.GanreServer.Id,
                    Name = bookServerDTO.GanreServer.Name,
                }
            };
    }
    
}
