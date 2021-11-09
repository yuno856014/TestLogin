using Microsoft.EntityFrameworkCore.Migrations;

namespace StuManagement.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0c6661b-0964-4e62-8083-3cac6a6741ec", "1", "Student", "Student" },
                    { "32ffd287-205f-43a2-9f0d-80sc5309fb47", "2", "Customer", "Family" },
                    { "ca6f2a10-c3bc-4a1a-b947-235974cd191b", "3", "Customer", "Teacher" },
                    { "83e8db1d-72b7-4313-b287-0e937f4af852", "4", "Customer", "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "Avatar", "ConcurrencyStamp", "CreateDate", "Discriminator", "Email", "EmailConfirmed", "LastLogin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "Password", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "ScholasticId", "SecurityStamp", "StudentCode", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2c0fca4e-9376-4a70-bcc6-35bebe497866", 0, null, "/images/icons/avatar4.png", "110bd236-a2f9-43bf-bb8d-eb14c3bc8b46", null, "User", "student@gmail.com", false, null, false, null, "student@gmail.com", "student@gmail.com", null, null, "AQAAAAEAACcQAAAAEPaVi3SnVI7dPGv1FHRL33kWVTczIwMKBgPorlOMMC45bnU9/rR5D4ZjA2ej2dRXrQ==", null, null, false, null, null, "010e52b7-90c1-471c-8af8-5cea09069e7c", null, false, "Student" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c0c6661b-0964-4e62-8083-3cac6a6741ec", "2c0fca4e-9376-4a70-bcc6-35bebe497866" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32ffd287-205f-43a2-9f0d-80sc5309fb47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83e8db1d-72b7-4313-b287-0e937f4af852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca6f2a10-c3bc-4a1a-b947-235974cd191b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c0c6661b-0964-4e62-8083-3cac6a6741ec", "2c0fca4e-9376-4a70-bcc6-35bebe497866" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0c6661b-0964-4e62-8083-3cac6a6741ec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c0fca4e-9376-4a70-bcc6-35bebe497866");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Events",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Events",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
