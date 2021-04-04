using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchTemp.Migrations
{
    public partial class resume_table_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Candidates_CandidateId",
                table: "Resumes");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Resumes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Candidates_CandidateId",
                table: "Resumes",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Candidates_CandidateId",
                table: "Resumes");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Resumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Candidates_CandidateId",
                table: "Resumes",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
