namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO
{
    public partial class AuthorServerDTO
    {
        public int Id { get; set; }

        public string Fio { get; set; } = null!;

        public int? Age { get; set; }

        public string Experience { get; set; } = null!;

        public static explicit operator AuthorServerDTO(
            Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.GanreShedBd authorShedBd) => new AuthorServerDTO
            {
                Id = authorShedBd.Id,
                Age = authorShedBd.Age,
                Experience = authorShedBd.Experience,
                Fio = authorShedBd.Fio,
            };

        public static explicit operator GanreShedBd(
            AuthorServerDTO autthorServerDTO) => new GanreShedBd
            {
                Id = autthorServerDTO.Id,
                Age = autthorServerDTO.Age,
                Experience= autthorServerDTO.Experience,
                Fio = autthorServerDTO.Fio
            };
    }
}
