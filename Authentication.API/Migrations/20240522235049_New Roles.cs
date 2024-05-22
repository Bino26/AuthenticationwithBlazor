using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.API.Migrations
{
    /// <inheritdoc />
    public partial class NewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a54b3a9-173a-470a-b6f4-008fb4443dd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3537521-1f1b-4d0c-89f3-15de5ec27670");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25376fb7-3775-49f3-8619-51ca819986dc", "25376fb7-3775-49f3-8619-51ca819986dc", "Writer", "WRITER" },
                    { "d3ecec29-e758-4d4e-8cf5-69f992098960", "d3ecec29-e758-4d4e-8cf5-69f992098960", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25376fb7-3775-49f3-8619-51ca819986dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3ecec29-e758-4d4e-8cf5-69f992098960");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a54b3a9-173a-470a-b6f4-008fb4443dd2", "3a54b3a9-173a-470a-b6f4-008fb4443dd2", "Writer", "WRITER" },
                    { "d3537521-1f1b-4d0c-89f3-15de5ec27670", "d3537521-1f1b-4d0c-89f3-15de5ec27670", "Reader", "READER" }
                });
        }
    }
}
