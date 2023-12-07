using System;
using System.Collections.Generic;

namespace ATEC_BOOK_LENDING.Model;

public partial class Book
{
    public long BookId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Icount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? Active { get; set; }
}
