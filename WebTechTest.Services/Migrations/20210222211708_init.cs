using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTechTest.Services.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Test-1");

            migrationBuilder.EnsureSchema(
                name: "Test-3");

            migrationBuilder.CreateTable(
                name: "AdGroup",
                schema: "Test-1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Test-1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "Test-3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonAdGroup",
                schema: "Test-1",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    AdGroupId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAdGroup", x => new { x.PersonId, x.AdGroupId });
                    table.ForeignKey(
                        name: "FK_PersonAdGroup_AdGroup_AdGroupId",
                        column: x => x.AdGroupId,
                        principalSchema: "Test-1",
                        principalTable: "AdGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAdGroup_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Test-1",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "Test-3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Test-3",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                schema: "Test-3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Mark = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluation_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Test-3",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonAdGroup_AdGroupId",
                schema: "Test-1",
                table: "PersonAdGroup",
                column: "AdGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_StudentId",
                schema: "Test-3",
                table: "Course",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_CourseId",
                schema: "Test-3",
                table: "Evaluation",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAdGroup",
                schema: "Test-1");

            migrationBuilder.DropTable(
                name: "Evaluation",
                schema: "Test-3");

            migrationBuilder.DropTable(
                name: "AdGroup",
                schema: "Test-1");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Test-1");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "Test-3");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "Test-3");
        }
    }
}
