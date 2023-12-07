using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATEC_BOOK_LENDING.Model;

public partial class User
{
    public long UserId { get; set; }


    //[Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public string? Surname { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? Active { get; set; }
}
