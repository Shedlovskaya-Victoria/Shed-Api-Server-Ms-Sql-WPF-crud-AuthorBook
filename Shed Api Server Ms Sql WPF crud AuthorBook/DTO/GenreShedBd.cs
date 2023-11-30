using System;
using System.Collections.Generic;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;

public partial class GenreShedBd
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BookShedBd> BookShedBds { get; set; } = new List<BookShedBd>();
}
