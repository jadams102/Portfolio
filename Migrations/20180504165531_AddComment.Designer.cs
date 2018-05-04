using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Portfolio.Models;

namespace Portfolio.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20180504165531_AddComment")]
    partial class AddComment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

            modelBuilder.Entity("Portfolio.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int>("PostId");

                    b.Property<string>("User");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

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

            modelBuilder.Entity("Portfolio.Models.Comment", b =>
                {
                    b.HasOne("Portfolio.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
