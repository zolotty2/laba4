﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LAB4.Models;

public partial class AppContext : DbContext
{
    public AppContext()
    {
    }

    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnimeTitle> AnimeTitles { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TitlesGenre> TitlesGenres { get; set; }

    public virtual DbSet<TitlesStatus> TitlesStatuses { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=anime_titles;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimeTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("anime_titles_pkey");

            entity.ToTable("anime_titles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountSeries).HasColumnName("count_series");
            entity.Property(e => e.Discription).HasColumnName("discription");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.IdType)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_type");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OriginalName).HasColumnName("original name");
            entity.Property(e => e.Poster).HasColumnName("poster");
            entity.Property(e => e.Studio).HasColumnName("studio");

            entity.HasOne(d => d.Type).WithMany(p => p.AnimeTitles)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("fk_titles_to_types");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genres_pkey");

            entity.ToTable("genres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreName).HasColumnName("genre_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ststuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('ststuses_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<TitlesGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("titles_genres_pkey");

            entity.ToTable("titles_genres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAnime).HasColumnName("id_anime");
            entity.Property(e => e.IdGenre).HasColumnName("id_genre");

            entity.HasOne(d => d.AnimeTitle).WithMany(p => p.TitlesGenres)
                .HasForeignKey(d => d.IdAnime)
                .HasConstraintName("fk_titles_genres_to_anime_titles");

            entity.HasOne(d => d.Genre).WithMany(p => p.TitlesGenres)
                .HasForeignKey(d => d.IdGenre)
                .HasConstraintName("fk_titles_genres_to_genres");
        });

        modelBuilder.Entity<TitlesStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("titles_statuses_pkey");

            entity.ToTable("titles_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateStatuses).HasColumnName("date_statuses");
            entity.Property(e => e.IdAnime).HasColumnName("id_anime");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");

            entity.HasOne(d => d.AnimeTitle).WithMany(p => p.TitlesStatuses)
                .HasForeignKey(d => d.IdAnime)
                .HasConstraintName("fk_titles_statuses_to_anime_titles");

            entity.HasOne(d => d.Status).WithMany(p => p.TitlesStatuses)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("fk_titles_statuses_to_statuses");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("types_pkey");

            entity.ToTable("types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName).HasColumnName("type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
