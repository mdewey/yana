using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOverflow.Data.Migrations
{
    public partial class connectingtodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentsModel_StackOverflow.Models.AnswersModel_AnswersModelId",
                table: "CommentsModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StackOverflow.Models.AnswersModel_QuestionsModel_QuestionModelId",
                table: "StackOverflow.Models.AnswersModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StackOverflow.Models.AnswersModel_UserModel_UserModelId",
                table: "StackOverflow.Models.AnswersModel");

            migrationBuilder.DropTable(
                name: "AnswerModel");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_StackOverflow.Models.AnswersModel_TempId",
                table: "StackOverflow.Models.AnswersModel");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "StackOverflow.Models.AnswersModel");

            migrationBuilder.DropColumn(
                name: "AnswersModelId",
                table: "CommentsModel");

            migrationBuilder.RenameTable(
                name: "StackOverflow.Models.AnswersModel",
                newName: "AnswersModel");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AnswersModel",
                type: "int4",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "AnswersModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostDate",
                table: "AnswersModel",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "AnswersModel",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "AnswersModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoteCount",
                table: "AnswersModel",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "QuestionsModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "CommentsModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswersModel",
                table: "AnswersModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersModel_QuestionModelId",
                table: "AnswersModel",
                column: "QuestionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersModel_UserModelId",
                table: "AnswersModel",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersModel_QuestionsModel_QuestionModelId",
                table: "AnswersModel",
                column: "QuestionModelId",
                principalTable: "QuestionsModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersModel_UserModel_UserModelId",
                table: "AnswersModel",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsModel_AnswersModel_AnswerModelId",
                table: "CommentsModel",
                column: "AnswerModelId",
                principalTable: "AnswersModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersModel_QuestionsModel_QuestionModelId",
                table: "AnswersModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswersModel_UserModel_UserModelId",
                table: "AnswersModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentsModel_AnswersModel_AnswerModelId",
                table: "CommentsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswersModel",
                table: "AnswersModel");

            migrationBuilder.DropIndex(
                name: "IX_AnswersModel_QuestionModelId",
                table: "AnswersModel");

            migrationBuilder.DropIndex(
                name: "IX_AnswersModel_UserModelId",
                table: "AnswersModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AnswersModel");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "AnswersModel");

            migrationBuilder.DropColumn(
                name: "PostDate",
                table: "AnswersModel");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "AnswersModel");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AnswersModel");

            migrationBuilder.DropColumn(
                name: "VoteCount",
                table: "AnswersModel");

            migrationBuilder.RenameTable(
                name: "AnswersModel",
                newName: "StackOverflow.Models.AnswersModel");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "QuestionsModel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "CommentsModel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnswersModelId",
                table: "CommentsModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "StackOverflow.Models.AnswersModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StackOverflow.Models.AnswersModel_TempId",
                table: "StackOverflow.Models.AnswersModel",
                column: "TempId");

            migrationBuilder.CreateTable(
                name: "AnswerModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Body = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    QuestionModelId = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    UserModelId = table.Column<int>(nullable: true),
                    VoteCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerModel_QuestionModelId",
                table: "AnswerModel",
                column: "QuestionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerModel_UserModelId",
                table: "AnswerModel",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsModel_StackOverflow.Models.AnswersModel_AnswersModelId",
                table: "CommentsModel",
                column: "AnswersModelId",
                principalTable: "StackOverflow.Models.AnswersModel",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StackOverflow.Models.AnswersModel_QuestionsModel_QuestionModelId",
                table: "StackOverflow.Models.AnswersModel",
                column: "QuestionModelId",
                principalTable: "QuestionsModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StackOverflow.Models.AnswersModel_UserModel_UserModelId",
                table: "StackOverflow.Models.AnswersModel",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
