using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T2207A_MVC.Migrations
{
    /// <inheritdoc />
    public partial class t2207a_t4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Brand_brand_id",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Brands_brand_id",
                table: "products",
                column: "brand_id",
                principalTable: "Brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Brands_brand_id",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Brand_brand_id",
                table: "products",
                column: "brand_id",
                principalTable: "Brand",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
