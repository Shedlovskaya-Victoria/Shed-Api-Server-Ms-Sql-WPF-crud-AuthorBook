using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;
using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO.ServerDTO;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.Service
{
    public class BookCRUD
    {
        public void Add(BookShedBd book)
        { 
            BD.GetInstance().BookShedBds.Add(book);
            BD.GetInstance().SaveChanges();
        }
        public void Edit(BookShedBd book)
        {
            BD.GetInstance().BookShedBds.FirstOrDefault(s => s.Id == book.Id).Title = book.Title;
            BD.GetInstance().BookShedBds.FirstOrDefault(s => s.Id == book.Id).Description = book.Description; ;
            BD.GetInstance().BookShedBds.FirstOrDefault(s => s.Id == book.Id).IdGenre = book.IdGenre;
            BD.GetInstance().BookShedBds.FirstOrDefault(s => s.Id == book.Id).IdGenreNavigation = book.IdGenreNavigation;

            BD.GetInstance().SaveChanges();
        }
        public void Delete(BookShedBd book)
        {
            var exemplar = BD.GetInstance().BookShedBds.FirstOrDefault(a => a.Id == book.Id);
            BD.GetInstance().BookShedBds.Remove(exemplar);
            BD.GetInstance().SaveChanges();
        }
       
    }
}
