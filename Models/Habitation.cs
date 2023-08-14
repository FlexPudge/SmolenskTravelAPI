using System;
using System.Collections.Generic;

namespace SmolenskTravelRESTFullAPI.Models;

public partial class Habitation
{
    public int Idtour { get; set; }

    public string? DiscriptionHabitation { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
