using System;
using System.Collections.Generic;

namespace TacoFastFoodAPI.Models;

public partial class Drink
{
    public int DrinkId { get; set; }

    public string? DrinkName { get; set; }

    public float? Cost { get; set; }

    public bool? Slushie { get; set; }

    public virtual ICollection<Combo> Combos { get; set; } = new List<Combo>();
}
