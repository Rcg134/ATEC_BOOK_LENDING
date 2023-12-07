using System;
using System.Collections.Generic;

namespace ATEC_BOOK_LENDING.Model;

public partial class Transaction
{
    public long Id { get; set; }

    public int? UserId { get; set; }

    public int? BokkId { get; set; }

    public int? IcountBorrowedItems { get; set; }

    public DateTime? BorrowedDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public bool? IsReturn { get; set; }
}
