using System;
using System.Collections.Generic;

namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;

public partial class BookShedBd
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int IdGenre { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CrossAuthorBookShedBd> CrossAuthorBookShedBds { get; set; } = new List<CrossAuthorBookShedBd>();

    public virtual GenreShedBd IdGenreNavigation { get; set; } = null!;
}
