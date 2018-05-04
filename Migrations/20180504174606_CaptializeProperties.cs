using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class CaptializeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Posts",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "Posts",
                newName: "Body");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Posts",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Posts",
                newName: "body");
        }
    }
}
