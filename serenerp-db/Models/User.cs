using System;
using System.Collections.Generic;

namespace serenerp_db.Models;

public partial class User
{
    public string Uid { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
