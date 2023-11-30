using System;
using System.Collections.Generic;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;

public partial class CrossAuthorBookShedBd
{
    public int Id { get; set; }

    public int IdAuthhor { get; set; }

    public int IdBook { get; set; }

    public virtual GanreShedBd IdAuthhorNavigation { get; set; } = null!;

    public virtual BookShedBd IdBookNavigation { get; set; } = null!;
}
