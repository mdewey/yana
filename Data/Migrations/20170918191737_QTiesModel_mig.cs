using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOverflow.Data.Migrations
{
    public partial class QTiesModel_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Body = table.Column<string>(type: "text", nullable: true),
                    PostDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<int>(type: "int4", nullable: false),
                    UserModelId = table.Column<int>(type: "int4", nullable: true),
                    VoteCount = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsModel_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagsModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TagName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QTiesModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuestionID = table.Column<int>(type: "int4", nullable: false),
                    QuestionsModelId = table.Column<int>(type: "int4", nullable: true),
                    TagID = table.Column<int>(type: "int4", nullable: false),
                    TagsModelID = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QTiesModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QTiesModel_QuestionsModel_QuestionsModelId",
                        column: x => x.QuestionsModelId,
                        principalTable: "QuestionsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QTiesModel_TagsModel_TagsModelID",
                        column: x => x.TagsModelID,
                        principalTable: "TagsModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QTiesModel_QuestionsModelId",
                table: "QTiesModel",
                column: "QuestionsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_QTiesModel_TagsModelID",
                table: "QTiesModel",
                column: "TagsModelID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsModel_UserModelId",
                table: "QuestionsModel",
                column: "UserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QTiesModel");

            migrationBuilder.DropTable(
                name: "QuestionsModel");

            migrationBuilder.DropTable(
                name: "TagsModel");
        }
    }
}
