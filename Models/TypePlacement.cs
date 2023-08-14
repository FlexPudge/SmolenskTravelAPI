using System;
using System.Collections.Generic;

namespace SmolenskTravelRESTFullAPI.Models;

public partial class TypePlacement
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
