﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPartners")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StadiumName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StadiumName")
                        .IsUnique()
                        .HasFilter("[StadiumName] IS NOT NULL");

                    b.ToTable("Clubs", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocalClubId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("VisitingClubId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocalClubId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("VisitingClubId");

                    b.ToTable("Matchs", "dbo");
                });

            modelBuilder.Entity("Model.Entities.MatchResult", b =>
                {
                    b.Property<int>("Matchid")
                        .HasColumnType("int");

                    b.Property<int>("LocalClubGoals")
                        .HasColumnType("int");

                    b.Property<int>("VisitingClubGoals")
                        .HasColumnType("int");

                    b.HasKey("Matchid");

                    b.ToTable("MatchsResults", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Players", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Regulation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FireExitAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Regulations");
                });

            modelBuilder.Entity("Model.Entities.ResponseAudit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResponseAudits");
                });

            modelBuilder.Entity("Model.Entities.Stadium", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Aux")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Stadiums", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Standing", b =>
                {
                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("Draw")
                        .HasColumnType("int");

                    b.Property<int>("Loss")
                        .HasColumnType("int");

                    b.Property<int>("Win")
                        .HasColumnType("int");

                    b.HasKey("TournamentId", "ClubId");

                    b.HasIndex("ClubId")
                        .IsUnique();

                    b.ToTable("Standings", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tournaments", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Club", b =>
                {
                    b.HasOne("Model.Entities.Stadium", "Stadium")
                        .WithOne("Club")
                        .HasForeignKey("Model.Entities.Club", "StadiumName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("Model.Entities.Match", b =>
                {
                    b.HasOne("Model.Entities.Club", "LocalClub")
                        .WithMany()
                        .HasForeignKey("LocalClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Entities.Tournament", null)
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Club", "VisitingClub")
                        .WithMany()
                        .HasForeignKey("VisitingClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LocalClub");

                    b.Navigation("VisitingClub");
                });

            modelBuilder.Entity("Model.Entities.MatchResult", b =>
                {
                    b.HasOne("Model.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("Matchid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Model.Entities.Player", b =>
                {
                    b.HasOne("Model.Entities.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Model.Entities.Standing", b =>
                {
                    b.HasOne("Model.Entities.Club", "Club")
                        .WithOne()
                        .HasForeignKey("Model.Entities.Standing", "ClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Entities.Tournament", "Tournament")
                        .WithMany("Standings")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Model.Entities.Club", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Model.Entities.Stadium", b =>
                {
                    b.Navigation("Club");
                });

            modelBuilder.Entity("Model.Entities.Tournament", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Standings");
                });
#pragma warning restore 612, 618
        }
    }
}
