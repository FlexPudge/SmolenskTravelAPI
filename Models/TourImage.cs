using System;
using System.Collections.Generic;

namespace SmolenskTravelRESTFullAPI.Models;

public partial class TourImage
{
    public int Id { get; set; }

    public int? Idtour { get; set; }

    public int? Idimage { get; set; }

    public virtual Image? IdimageNavigation { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
