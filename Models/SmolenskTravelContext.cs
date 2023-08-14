using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmolenskTravelRESTFullAPI.Models;

public partial class SmolenskTravelContext : DbContext
{
    public SmolenskTravelContext()
    {
    }

    public SmolenskTravelContext(DbContextOptions<SmolenskTravelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Complexity> Complexities { get; set; }

    public virtual DbSet<Habitation> Habitations { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<ProgramTour> ProgramTours { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TourImage> TourImages { get; set; }

    public virtual DbSet<TypePlacement> TypePlacements { get; set; }

    public virtual DbSet<TypeTour> TypeTours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-4V4BR0L;User=DESKTOP-4V4BR0L\\\\\\\\Misha;Initial Catalog=SmolenskTravel;integrated security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Complexity>(entity =>
        {
            entity.ToTable("Complexity");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Habitation>(entity =>
        {
            entity.ToTable("Habitation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiscriptionHabitation).HasColumnType("xml");
            entity.Property(e => e.Idtour).HasColumnName("IDTour");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Image1)
                .HasColumnType("image")
                .HasColumnName("Image");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ProgramTour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Program");

            entity.ToTable("ProgramTour");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescriptionProgram).HasColumnType("xml");
            entity.Property(e => e.Idtour).HasColumnName("IDTour");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.ToTable("Tour");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Idcomplexity).HasColumnName("IDComplexity");
            entity.Property(e => e.Idhabitation).HasColumnName("IDHabitation");
            entity.Property(e => e.Idphoto).HasColumnName("IDPhoto");
            entity.Property(e => e.Idprogram).HasColumnName("IDProgram");
            entity.Property(e => e.Idregion).HasColumnName("IDRegion");
            entity.Property(e => e.Idtype).HasColumnName("IDType");
            entity.Property(e => e.IdtypePlacement).HasColumnName("IDTypePlacement");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.IdcomplexityNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Idcomplexity)
                .HasConstraintName("FK_Tour_Complexity");

            entity.HasOne(d => d.IdhabitationNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Idhabitation)
                .HasConstraintName("FK_Tour_Habitation");

            entity.HasOne(d => d.IdphotoNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Idphoto)
                .HasConstraintName("FK_Tour_Tour_Image");

            entity.HasOne(d => d.IdprogramNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Idprogram)
                .HasConstraintName("FK_Tour_Program");

            entity.HasOne(d => d.IdregionNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Idregion)
                .HasConstraintName("FK_Tour_Region");

            entity.HasOne(d => d.IdtypeNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Idtype)
                .HasConstraintName("FK_Tour_TypeTour");

            entity.HasOne(d => d.IdtypePlacementNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.IdtypePlacement)
                .HasConstraintName("FK_Tour_TypePlacement");
        });

        modelBuilder.Entity<TourImage>(entity =>
        {
            entity.ToTable("Tour_Image");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idimage).HasColumnName("IDImage");
            entity.Property(e => e.Idtour).HasColumnName("IDTour");

            entity.HasOne(d => d.IdimageNavigation).WithMany(p => p.TourImages)
                .HasForeignKey(d => d.Idimage)
                .HasConstraintName("FK_Tour_Image_Image");
        });

        modelBuilder.Entity<TypePlacement>(entity =>
        {
            entity.ToTable("TypePlacement");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeTour>(entity =>
        {
            entity.ToTable("TypeTour");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
