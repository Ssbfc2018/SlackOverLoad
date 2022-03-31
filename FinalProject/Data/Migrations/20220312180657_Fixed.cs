using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class Fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_CommentToAnswerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_CommentToQuestionId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentToAnswerId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CommentToQuestionId",
                table: "Comments",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "CommentToAnswerId",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentToQuestionId",
                table: "Comments",
                newName: "IX_Comments_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnswerId",
                table: "Comments",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_AnswerId",
                table: "Comments",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_QuestionId",
                table: "Comments",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_AnswerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_QuestionId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnswerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Comments",
                newName: "CommentToQuestionId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "CommentToAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_QuestionId",
                table: "Comments",
                newName: "IX_Comments_CommentToQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentToAnswerId",
                table: "Comments",
                column: "CommentToAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_CommentToAnswerId",
                table: "Comments",
                column: "CommentToAnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_CommentToQuestionId",
                table: "Comments",
                column: "CommentToQuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }
    }
}
