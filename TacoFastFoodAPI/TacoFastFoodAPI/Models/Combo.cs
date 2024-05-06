﻿using System;
using System.Collections.Generic;

namespace TacoFastFoodAPI.Models;

public partial class Combo
{
    public int ComboId { get; set; }

    public string? ComboName { get; set; }

    public float? Cost { get; set; }

    public int? TacoId { get; set; }

    public int? DrinkId { get; set; }

    public virtual Drink? Drink { get; set; }

    public virtual Taco? Taco { get; set; }
}
