using System;
using System.Collections.Generic;

namespace SmolenskTravelRESTFullAPI.Models;

public partial class Image
{
    public int Id { get; set; }

    public byte[]? Image1 { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TourImage> TourImages { get; set; } = new List<TourImage>();
}
