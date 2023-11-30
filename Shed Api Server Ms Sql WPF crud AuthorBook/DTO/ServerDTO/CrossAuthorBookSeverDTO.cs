using System.Collections.ObjectModel;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO
{
    public class CrossAuthorBookSeverDTO
    {
        public int Id { get; set; }

        public int IdAuthhor { get; set; }

        public int IdBook { get; set; }
        public AuthorServerDTO Authors { get; set; } = new AuthorServerDTO();
        public BookServerDTO Books { get; set; } = new BookServerDTO();

        public static explicit operator CrossAuthorBookSeverDTO(
            Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.CrossAuthorBookShedBd crossAuthorBookShedBd) => new CrossAuthorBookSeverDTO
            {
                Id = crossAuthorBookShedBd.Id,
                IdBook = crossAuthorBookShedBd.IdBook,
                IdAuthhor = crossAuthorBookShedBd.IdAuthhor,
                Authors = new AuthorServerDTO
                {
                    Id = crossAuthorBookShedBd.IdAuthhorNavigation.Id,
                    Age = crossAuthorBookShedBd.IdAuthhorNavigation.Age,
                    Experience = crossAuthorBookShedBd.IdAuthhorNavigation.Experience,
                    Fio = crossAuthorBookShedBd.IdAuthhorNavigation.Fio
                },
                Books = new BookServerDTO
                {
                    Id = crossAuthorBookShedBd.IdBookNavigation.Id,
                    Description = crossAuthorBookShedBd.IdBookNavigation.Description,
                    Title = crossAuthorBookShedBd.IdBookNavigation.Title,
                    IdGenre = crossAuthorBookShedBd.IdBookNavigation.IdGenre,
                    GanreServer = new GanreServerDTO
                    {
                        Id = crossAuthorBookShedBd.IdBookNavigation.IdGenreNavigation.Id,
                        Name = crossAuthorBookShedBd.IdBookNavigation.IdGenreNavigation.Name
                    }
                }

            };
        public static explicit operator CrossAuthorBookShedBd(
            Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO.CrossAuthorBookSeverDTO crossAuthorBookSever) => new CrossAuthorBookShedBd
            {
                Id = crossAuthorBookSever.Id,
                IdBook = crossAuthorBookSever.IdBook,
                IdAuthhor = crossAuthorBookSever.IdAuthhor,
                IdAuthhorNavigation = new GanreShedBd
                {
                    Id = crossAuthorBookSever.IdAuthhor,
                    Age = crossAuthorBookSever.Authors.Age,
                    Fio = crossAuthorBookSever.Authors.Fio,
                    Experience = crossAuthorBookSever.Authors.Experience
                },
                IdBookNavigation = new BookShedBd
                {
                    Id = crossAuthorBookSever.Books.Id,
                    Description = crossAuthorBookSever.Books.Description,
                    Title = crossAuthorBookSever.Books.Title,
                    IdGenre = crossAuthorBookSever.Books.IdGenre,
                    IdGenreNavigation = new GenreShedBd
                    {
                        Id = crossAuthorBookSever.Books.IdGenre,
                        Name = crossAuthorBookSever.Books.GanreServer.Name
                    }
                }
            };
    }
}
