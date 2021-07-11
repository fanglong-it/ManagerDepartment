using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyPhongBan.Migrations
{
    public partial class updatedatabasever20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChucVu",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "44313269-376d-4b0d-ad3a-e15a0ba80a7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99eceafe-bd32-4351-ab83-439fc992b426", "AQAAAAEAACcQAAAAEA3B7f+j/Qk+z8G+Gx8fwCsWIxyADsfYvLgx0mwHQ8+p3pwFArK6/ZiScgu7+jMCRA==", "96762107-20fa-4ca9-b350-0f5b1e8f3c11" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChucVu",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "9e6d1fb9-533c-4ab4-97c1-61352684c30c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46ab75c0-b62e-4983-a955-282f1215341f", "AQAAAAEAACcQAAAAEBPv1JSbQ3ydpOIxgiZS7dlzzQBMtj/xSuVWcx/qV+AXaE3BtjsIOtbYztWOGxhSMw==", "f82e2924-fda4-413e-93b5-8656e83af796" });
        }
    }
}
