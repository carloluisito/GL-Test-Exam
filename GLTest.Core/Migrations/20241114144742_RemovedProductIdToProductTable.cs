using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GLTest.Core.Migrations
{
    /// <inheritdoc />
    public partial class RemovedProductIdToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
