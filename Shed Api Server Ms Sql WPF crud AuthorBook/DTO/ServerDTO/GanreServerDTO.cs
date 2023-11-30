namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO
{
    public partial class GanreServerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public static explicit operator GanreServerDTO(
       Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.GenreShedBd genreShedBd) => new GanreServerDTO
       {
           Id = genreShedBd.Id,
           Name = genreShedBd.Name,
       };
        public static explicit operator GenreShedBd(
      Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO.GanreServerDTO ganreServerDTO) => new GenreShedBd
      {
          Id = ganreServerDTO.Id,
          Name = ganreServerDTO.Name,
      };
    }
   
}
