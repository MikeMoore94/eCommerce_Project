using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceStarterCode.Migrations
{
    public partial class lg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Name",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ShoppingCarts",
                newName: "CartId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c073f42c-79e8-41a6-a5d7-0ed41ae7aca0", "df8961da-91f7-4729-a4aa-312b6fcd7c8f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a85197de-2346-492e-861e-08b0370b485f", "27e54b6b-7578-4229-8a3e-7a5a5651df3b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a85197de-2346-492e-861e-08b0370b485f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c073f42c-79e8-41a6-a5d7-0ed41ae7aca0");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "ShoppingCarts",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShoppingCarts",
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
    }
}
