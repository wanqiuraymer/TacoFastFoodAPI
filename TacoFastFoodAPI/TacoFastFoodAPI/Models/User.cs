using System;
using System.Collections.Generic;

namespace TacoFastFoodAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? ApiKey { get; set; }
}
