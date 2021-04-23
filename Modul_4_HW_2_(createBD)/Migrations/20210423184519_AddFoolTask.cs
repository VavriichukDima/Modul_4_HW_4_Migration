using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Modul_4_HW_2__createBD_.Migrations
{
    public partial class AddFoolTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("INSERT INTO Client(FirstName, LastName, DateOfBirth, Company) VALUES('FirstTest', 'LastTest', '1991-01-01', 'NoNameCompany')");
            migrationBuilder.Sql("INSERT INTO Client(FirstName, LastName, DateOfBirth, Company) VALUES('Bill', 'Gates', '1992-01-01', 'MikroSoft')");
            migrationBuilder.Sql("INSERT INTO Client(FirstName, LastName, DateOfBirth, Company) VALUES('Mark', 'Zuckerberg', '1993-01-01', 'FB')");
            migrationBuilder.Sql("INSERT INTO Client(FirstName, LastName, DateOfBirth, Company) VALUES('Steven', 'Jobs', '1994-01-01', 'Apple')");
            migrationBuilder.Sql("INSERT INTO Client(FirstName, LastName, DateOfBirth, Company) VALUES('Dima', 'Vavriichuk', '1993-09-30', 'BestOfTheBest')");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Foo', 100000, '1999-12-31', 1)");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Boo', 100000, '1999-12-31', 2)");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Loo', 100000, '1999-12-31', 3)");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Moo', 100000, '1999-12-31', 4)");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Best', 1000000000, '1999-12-31', 5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
