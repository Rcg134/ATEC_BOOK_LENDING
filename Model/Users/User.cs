using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATEC_BOOK_LENDING.Model.Users;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}
