using System;
using System.Collections.Generic;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;

public partial class GanreShedBd
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int? Age { get; set; }

    public string Experience { get; set; } = null!;

    public virtual ICollection<CrossAuthorBookShedBd> CrossAuthorBookShedBds { get; set; } = new List<CrossAuthorBookShedBd>();
}
