using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Portfolio.Models;

namespace Portfolio.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20180504160934_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

            modelBuilder.Entity("Portfolio.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("body");

                    b.Property<DateTime>("date");

                    b.Property<string>("title");

                    b.HasKey("PostId");

                    b.ToTable("Posts");
                });
        }
    }
}
