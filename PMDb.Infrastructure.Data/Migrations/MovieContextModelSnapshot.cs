﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PMDb.Infrastructure.Data;
using System;

namespace PMDb.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PMDb.Domain.Core.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("PMDb.Domain.Core.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("PMDb.Domain.Core.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("PMDb.Domain.Core.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IMDbId");

                    b.Property<string>("Poster");

                    b.Property<string>("Title");

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieActor", b =>
                {
                    b.Property<int>("ActorId");

                    b.Property<int>("MovieId");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieActor");
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieDirector", b =>
                {
                    b.Property<int>("DirectorId");

                    b.Property<int>("MovieId");

                    b.HasKey("DirectorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieDirector");
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieGenre", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<int>("MovieId");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieTag", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("MovieId");

                    b.HasKey("TagId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieTag");
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieWriter", b =>
                {
                    b.Property<int>("WriterId");

                    b.Property<int>("MovieId");

                    b.HasKey("WriterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieWriter");
                });

            modelBuilder.Entity("PMDb.Domain.Core.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("IMDbRating");

                    b.Property<int?>("IMDbVotes");

                    b.Property<double?>("MetaCriticRating");

                    b.Property<int>("MovieId");

                    b.Property<double?>("OwnRating");

                    b.Property<double?>("RotenTomatosRating");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("PMDb.Domain.Core.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PMDb.Domain.Core.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieActor", b =>
                {
                    b.HasOne("PMDb.Domain.Core.Actor", "Actor")
                        .WithMany("MovieActor")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMDb.Domain.Core.Movie", "Movie")
                        .WithMany("MovieActor")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieDirector", b =>
                {
                    b.HasOne("PMDb.Domain.Core.Director", "Director")
                        .WithMany("MovieDirector")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMDb.Domain.Core.Movie", "Movie")
                        .WithMany("MovieDirector")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieGenre", b =>
                {
                    b.HasOne("PMDb.Domain.Core.Genre", "Genre")
                        .WithMany("MovieGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMDb.Domain.Core.Movie", "Movie")
                        .WithMany("MovieGenre")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieTag", b =>
                {
                    b.HasOne("PMDb.Domain.Core.Movie", "Movie")
                        .WithMany("MovieTag")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMDb.Domain.Core.Tag", "Tag")
                        .WithMany("MovieTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMDb.Domain.Core.MovieWriter", b =>
                {
                    b.HasOne("PMDb.Domain.Core.Movie", "Movie")
                        .WithMany("MovieWriter")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMDb.Domain.Core.Writer", "Writer")
                        .WithMany("MovieWriter")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMDb.Domain.Core.Rating", b =>
                {
                    b.HasOne("PMDb.Domain.Core.Movie", "Movie")
                        .WithOne("Rating")
                        .HasForeignKey("PMDb.Domain.Core.Rating", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
