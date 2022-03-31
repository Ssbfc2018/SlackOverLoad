using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class FixedDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_AspNetUsers_UserId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Questions_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerVotation_Answer_AnswerId",
                table: "AnswerVotation");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerVotation_AspNetUsers_UserId",
                table: "AnswerVotation");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Answer_CommentToAnswerId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_CommentToCommentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Questions_CommentToQuestionId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTag_Questions_QuestionId",
                table: "QuestionTag");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTag_Tag_TagId",
                table: "QuestionTag");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionVotation_AspNetUsers_UserId",
                table: "QuestionVotation");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionVotation_Questions_QuestionId",
                table: "QuestionVotation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionVotation",
                table: "QuestionVotation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionTag",
                table: "QuestionTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerVotation",
                table: "AnswerVotation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "QuestionVotation",
                newName: "QuestionsVotations");

            migrationBuilder.RenameTable(
                name: "QuestionTag",
                newName: "QuestionsTags");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "AnswerVotation",
                newName: "AnswersVotations");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionVotation_UserId",
                table: "QuestionsVotations",
                newName: "IX_QuestionsVotations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionVotation_QuestionId",
                table: "QuestionsVotations",
                newName: "IX_QuestionsVotations_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTag_TagId",
                table: "QuestionsTags",
                newName: "IX_QuestionsTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTag_QuestionId",
                table: "QuestionsTags",
                newName: "IX_QuestionsTags_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CommentToQuestionId",
                table: "Comments",
                newName: "IX_Comments_CommentToQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CommentToCommentId",
                table: "Comments",
                newName: "IX_Comments_CommentToCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CommentToAnswerId",
                table: "Comments",
                newName: "IX_Comments_CommentToAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerVotation_UserId",
                table: "AnswersVotations",
                newName: "IX_AnswersVotations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerVotation_AnswerId",
                table: "AnswersVotations",
                newName: "IX_AnswersVotations_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_UserId",
                table: "Answers",
                newName: "IX_Answers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Answers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionsVotations",
                table: "QuestionsVotations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionsTags",
                table: "QuestionsTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswersVotations",
                table: "AnswersVotations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersVotations_Answers_AnswerId",
                table: "AnswersVotations",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersVotations_AspNetUsers_UserId",
                table: "AnswersVotations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_CommentToAnswerId",
                table: "Comments",
                column: "CommentToAnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentToCommentId",
                table: "Comments",
                column: "CommentToCommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_CommentToQuestionId",
                table: "Comments",
                column: "CommentToQuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsTags_Questions_QuestionId",
                table: "QuestionsTags",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsTags_Tags_TagId",
                table: "QuestionsTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsVotations_AspNetUsers_UserId",
                table: "QuestionsVotations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsVotations_Questions_QuestionId",
                table: "QuestionsVotations",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_UserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswersVotations_Answers_AnswerId",
                table: "AnswersVotations");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswersVotations_AspNetUsers_UserId",
                table: "AnswersVotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_CommentToAnswerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentToCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_CommentToQuestionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsTags_Questions_QuestionId",
                table: "QuestionsTags");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsTags_Tags_TagId",
                table: "QuestionsTags");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsVotations_AspNetUsers_UserId",
                table: "QuestionsVotations");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsVotations_Questions_QuestionId",
                table: "QuestionsVotations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionsVotations",
                table: "QuestionsVotations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionsTags",
                table: "QuestionsTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswersVotations",
                table: "AnswersVotations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "QuestionsVotations",
                newName: "QuestionVotation");

            migrationBuilder.RenameTable(
                name: "QuestionsTags",
                newName: "QuestionTag");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "AnswersVotations",
                newName: "AnswerVotation");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionsVotations_UserId",
                table: "QuestionVotation",
                newName: "IX_QuestionVotation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionsVotations_QuestionId",
                table: "QuestionVotation",
                newName: "IX_QuestionVotation_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionsTags_TagId",
                table: "QuestionTag",
                newName: "IX_QuestionTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionsTags_QuestionId",
                table: "QuestionTag",
                newName: "IX_QuestionTag_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentToQuestionId",
                table: "Comment",
                newName: "IX_Comment_CommentToQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentToCommentId",
                table: "Comment",
                newName: "IX_Comment_CommentToCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentToAnswerId",
                table: "Comment",
                newName: "IX_Comment_CommentToAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswersVotations_UserId",
                table: "AnswerVotation",
                newName: "IX_AnswerVotation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswersVotations_AnswerId",
                table: "AnswerVotation",
                newName: "IX_AnswerVotation_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_UserId",
                table: "Answer",
                newName: "IX_Answer_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answer",
                newName: "IX_Answer_QuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Answer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionVotation",
                table: "QuestionVotation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionTag",
                table: "QuestionTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerVotation",
                table: "AnswerVotation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_AspNetUsers_UserId",
                table: "Answer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Questions_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerVotation_Answer_AnswerId",
                table: "AnswerVotation",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerVotation_AspNetUsers_UserId",
                table: "AnswerVotation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Answer_CommentToAnswerId",
                table: "Comment",
                column: "CommentToAnswerId",
                principalTable: "Answer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_CommentToCommentId",
                table: "Comment",
                column: "CommentToCommentId",
                principalTable: "Comment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Questions_CommentToQuestionId",
                table: "Comment",
                column: "CommentToQuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTag_Questions_QuestionId",
                table: "QuestionTag",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTag_Tag_TagId",
                table: "QuestionTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionVotation_AspNetUsers_UserId",
                table: "QuestionVotation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionVotation_Questions_QuestionId",
                table: "QuestionVotation",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }
    }
}
