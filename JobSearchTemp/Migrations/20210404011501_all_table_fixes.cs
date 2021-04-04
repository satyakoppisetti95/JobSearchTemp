using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchTemp.Migrations
{
    public partial class all_table_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Candidates_CandidateId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobPostings_JobId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Resumes_ResumeId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_Employers_EmployerID",
                table: "JobPostings");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Candidates_CandidateId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Employers_EmployerID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "EmployerID",
                table: "Notifications",
                newName: "EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_EmployerID",
                table: "Notifications",
                newName: "IX_Notifications_EmployerId");

            migrationBuilder.RenameColumn(
                name: "EmployerID",
                table: "JobPostings",
                newName: "EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPostings_EmployerID",
                table: "JobPostings",
                newName: "IX_JobPostings_EmployerId");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "SavedSearches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobPostingId",
                table: "SavedSearches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "JobPostings",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobPostingId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobPostingId",
                table: "JobApplications",
                column: "JobPostingId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Candidates_CandidateId",
                table: "JobApplications",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobPostings_JobPostingId",
                table: "JobApplications",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Resumes_ResumeId",
                table: "JobApplications",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_Employers_EmployerId",
                table: "JobPostings",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Candidates_CandidateId",
                table: "Notifications",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Employers_EmployerId",
                table: "Notifications",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Candidates_CandidateId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobPostings_JobPostingId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Resumes_ResumeId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_Employers_EmployerId",
                table: "JobPostings");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Candidates_CandidateId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Employers_EmployerId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_JobPostingId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "SavedSearches");

            migrationBuilder.DropColumn(
                name: "JobPostingId",
                table: "SavedSearches");

            migrationBuilder.DropColumn(
                name: "JobPostingId",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "Notifications",
                newName: "EmployerID");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_EmployerId",
                table: "Notifications",
                newName: "IX_Notifications_EmployerID");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "JobPostings",
                newName: "EmployerID");

            migrationBuilder.RenameIndex(
                name: "IX_JobPostings_EmployerId",
                table: "JobPostings",
                newName: "IX_JobPostings_EmployerID");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerID",
                table: "Notifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Notifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerID",
                table: "JobPostings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "JobApplications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "JobApplications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "JobApplications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Candidates_CandidateId",
                table: "JobApplications",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobPostings_JobId",
                table: "JobApplications",
                column: "JobId",
                principalTable: "JobPostings",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Resumes_ResumeId",
                table: "JobApplications",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_Employers_EmployerID",
                table: "JobPostings",
                column: "EmployerID",
                principalTable: "Employers",
                principalColumn: "EmployerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Candidates_CandidateId",
                table: "Notifications",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Employers_EmployerID",
                table: "Notifications",
                column: "EmployerID",
                principalTable: "Employers",
                principalColumn: "EmployerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
