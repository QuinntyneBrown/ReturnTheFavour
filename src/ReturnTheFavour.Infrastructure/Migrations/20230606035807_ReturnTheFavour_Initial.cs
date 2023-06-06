using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReturnTheFavour.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReturnTheFavourInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ReturnTheFavour");

            migrationBuilder.CreateTable(
                name: "Measurements",
                schema: "ReturnTheFavour",
                columns: table => new
                {
                    MeasurementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasurementId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements",
                schema: "ReturnTheFavour");
        }
    }
}
