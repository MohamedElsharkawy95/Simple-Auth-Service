using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthAPI.Migrations;

/// <inheritdoc />
public partial class addUserTypesTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "UserTypeId",
            table: "AspNetUsers",
            type: "int",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "UserTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserTypes", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUsers_UserTypeId",
            table: "AspNetUsers",
            column: "UserTypeId");

        migrationBuilder.AddForeignKey(
            name: "FK_AspNetUsers_UserTypes_UserTypeId",
            table: "AspNetUsers",
            column: "UserTypeId",
            principalTable: "UserTypes",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_AspNetUsers_UserTypes_UserTypeId",
            table: "AspNetUsers");

        migrationBuilder.DropTable(
            name: "UserTypes");

        migrationBuilder.DropIndex(
            name: "IX_AspNetUsers_UserTypeId",
            table: "AspNetUsers");

        migrationBuilder.DropColumn(
            name: "UserTypeId",
            table: "AspNetUsers");
    }
}
