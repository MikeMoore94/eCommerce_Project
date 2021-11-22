using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceStarterCode.Migrations
{
    public partial class UpdatedProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "376636ab-f34b-4954-8dad-cba7aedee026");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b162547c-7f47-4efa-a02d-14cf8768190c");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f31a4c35-bee3-4cc9-9e47-511773af36ba", "4d9f2f1c-60b8-4652-8700-fc6dca3ad88f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2c4d027-e523-4921-8bfa-958f747102ba", "f3ddc5b2-25b7-41cd-a68b-9f579d0a3385", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2c4d027-e523-4921-8bfa-958f747102ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f31a4c35-bee3-4cc9-9e47-511773af36ba");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "376636ab-f34b-4954-8dad-cba7aedee026", "442e67e2-54eb-44ae-98ce-7524f37efc21", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b162547c-7f47-4efa-a02d-14cf8768190c", "ff231e89-352d-4c3e-b28f-b7fea491c6fc", "Admin", "ADMIN" });
        }
    }
}
