using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductApi.Migrations
{
    public partial class AddProductDataTableOnDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "[Products]",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(name: "[name]", type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(name: "[price]", type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(name: "[description]", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    category_name = table.Column<string>(name: "[category_name]", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    image_url = table.Column<string>(name: "[image_url]", type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Products]", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "[Products]");
        }
    }
}
