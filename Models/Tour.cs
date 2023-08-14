using System;
using System.Collections.Generic;

namespace SmolenskTravelRESTFullAPI.Models;

public partial class Tour
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Idregion { get; set; }

    public int? Idtype { get; set; }

    public int? Idcomplexity { get; set; }

    public int? IdtypePlacement { get; set; }

    public int? CountDay { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Price { get; set; }

    public int? CountHuman { get; set; }

    public int? Idphoto { get; set; }

    public int? Idprogram { get; set; }

    public int? Idhabitation { get; set; }

    public virtual Complexity? IdcomplexityNavigation { get; set; }

    public virtual Habitation? IdhabitationNavigation { get; set; }

    public virtual TourImage? IdphotoNavigation { get; set; }

    public virtual ProgramTour? IdprogramNavigation { get; set; }

    public virtual Region? IdregionNavigation { get; set; }

    public virtual TypeTour? IdtypeNavigation { get; set; }

    public virtual TypePlacement? IdtypePlacementNavigation { get; set; }
}
