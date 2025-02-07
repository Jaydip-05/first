using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace first.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Address", "DOB", "Email", "StudentName" },
                values: new object[,]
                {
                    { 1, "Pune", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jay59@gmail.com", "Jaydip" },
                    { 2, "Mumbai", new DateTime(2001, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahesh89@gmail.com", "Mahesh" },
                    { 3, "USA", new DateTime(2004, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "sam75@gmail.com", "Sam" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
