using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOverflow.Data.Migrations
{
    public partial class AnswersModel_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Body = table.Column<string>(type: "text", nullable: true),
                    PostDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    QuestionID = table.Column<int>(type: "int4", nullable: false),
                    QuestionModelId = table.Column<int>(type: "int4", nullable: true),
                    UserID = table.Column<int>(type: "int4", nullable: false),
                    UserModelId = table.Column<int>(type: "int4", nullable: true),
                    VoteCount = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerModel_QuestionsModel_QuestionModelId",
                        column: x => x.QuestionModelId,
                        principalTable: "QuestionsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerModel_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AnswerID = table.Column<int>(type: "int4", nullable: false),
                    AnswerModelId = table.Column<int>(type: "int4", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    PostDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    QuestionID = table.Column<int>(type: "int4", nullable: false),
                    QuestionModelId = table.Column<int>(type: "int4", nullable: true),
                    UserID = table.Column<int>(type: "int4", nullable: false),
                    UserModelId = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentsModel_AnswerModel_AnswerModelId",
                        column: x => x.AnswerModelId,
                        principalTable: "AnswerModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentsModel_QuestionsModel_QuestionModelId",
                        column: x => x.QuestionModelId,
                        principalTable: "QuestionsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentsModel_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerModel_QuestionModelId",
                table: "AnswerModel",
                column: "QuestionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerModel_UserModelId",
                table: "AnswerModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsModel_AnswerModelId",
                table: "CommentsModel",
                column: "AnswerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsModel_QuestionModelId",
                table: "CommentsModel",
                column: "QuestionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsModel_UserModelId",
                table: "CommentsModel",
                column: "UserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentsModel");

            migrationBuilder.DropTable(
                name: "AnswerModel");
        }
    }
}
