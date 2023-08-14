using System;
using System.Collections.Generic;

namespace SmolenskTravelRESTFullAPI.Models;

public partial class ProgramTour
{
    public int Id { get; set; }

    public int Idtour { get; set; }

    public string? DescriptionProgram { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
