using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GLTest.Core.Migrations
{
    /// <inheritdoc />
    public partial class MoveCategoryIdToProductCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ProductCategories (ProductId, CategoryId) SELECT ProductId, CategoryId FROM Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
