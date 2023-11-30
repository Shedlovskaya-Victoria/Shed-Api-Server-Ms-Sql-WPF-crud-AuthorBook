using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;
using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.Service
{
    public class AuthorCRUD
    {
        public void Add(GanreShedBd author)
        {
            BD.GetInstance().AuthorShedBds.Add(author);
            BD.GetInstance().SaveChanges();
        }
        public void Edit(GanreShedBd author)
        {
            BD.GetInstance().AuthorShedBds.FirstOrDefault(s=>s.Id == author.Id).Fio = author.Fio;
            BD.GetInstance().AuthorShedBds.FirstOrDefault(s=>s.Id == author.Id).Age = author.Age; ;
            BD.GetInstance().AuthorShedBds.FirstOrDefault(s => s.Id == author.Id).Experience = author.Experience;

            BD.GetInstance().SaveChanges();
        }
        public void Delete(GanreShedBd author)
        {
            var exemplar = BD.GetInstance().AuthorShedBds.FirstOrDefault(a => a.Id == author.Id);
            BD.GetInstance().AuthorShedBds.Remove(exemplar);
            BD.GetInstance().SaveChanges();
        }
    }
}
