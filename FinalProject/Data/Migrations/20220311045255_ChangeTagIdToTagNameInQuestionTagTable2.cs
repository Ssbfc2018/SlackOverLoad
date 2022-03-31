using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class ChangeTagIdToTagNameInQuestionTagTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsTags_Tags_TagId",
                table: "QuestionsTags");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "QuestionsTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "QuestionsTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsTags_Tags_TagId",
                table: "QuestionsTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsTags_Tags_TagId",
                table: "QuestionsTags");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "QuestionsTags");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "QuestionsTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsTags_Tags_TagId",
                table: "QuestionsTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
