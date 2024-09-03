using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Session4.Migrations
{
    /// <inheritdoc />
    public partial class Change_DepId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "DepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepId",
                table: "Departments",
                newName: "Id");
        }
    }
}
