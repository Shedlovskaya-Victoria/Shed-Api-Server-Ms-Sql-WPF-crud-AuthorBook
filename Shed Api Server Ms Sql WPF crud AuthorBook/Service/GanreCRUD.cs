using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.Service
{
    public class GanreCRUD
    {
        public void Add(GenreShedBd genre)
        {
            BD.GetInstance().GenreShedBds.Add(genre);
            BD.GetInstance().SaveChanges();
        }
        public void Edit(GenreShedBd genre)
        {
            BD.GetInstance().GenreShedBds.FirstOrDefault(s => s.Id == genre.Id).Name = genre.Name;

            BD.GetInstance().SaveChanges();
        }
        public void Delete(GenreShedBd genre)
        {
            var g = BD.GetInstance().GenreShedBds.FirstOrDefault(a => a.Id == genre.Id);
            BD.GetInstance().GenreShedBds.Remove(g);
            BD.GetInstance().SaveChanges();
        }
    }
}
