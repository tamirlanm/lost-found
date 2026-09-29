using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostAndFound.Api.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "found_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserFoundId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Cabinet = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    FoundAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PhotoKey = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_found_items", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_found_items_Status_Category_CreatedAt",
                table: "found_items",
                columns: new[] { "Status", "Category", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_found_items_UserFoundId",
                table: "found_items",
                column: "UserFoundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "found_items");
        }
    }
}
