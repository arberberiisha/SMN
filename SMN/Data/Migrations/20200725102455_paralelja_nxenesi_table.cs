using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMN.Data.Migrations
{
    public partial class paralelja_nxenesi_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmnUser_Paralelja_ParaleljaId",
                table: "SmnUser");

            migrationBuilder.DropIndex(
                name: "IX_SmnUser_ParaleljaId",
                table: "SmnUser");

            migrationBuilder.DropColumn(
                name: "ParaleljaId",
                table: "SmnUser");

            migrationBuilder.CreateTable(
                name: "ParaleljaNxenesi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NxenesiId = table.Column<Guid>(nullable: true),
                    ParaleljaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParaleljaNxenesi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParaleljaNxenesi_SmnUser_NxenesiId",
                        column: x => x.NxenesiId,
                        principalTable: "SmnUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParaleljaNxenesi_Paralelja_ParaleljaId",
                        column: x => x.ParaleljaId,
                        principalTable: "Paralelja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParaleljaNxenesi_NxenesiId",
                table: "ParaleljaNxenesi",
                column: "NxenesiId");

            migrationBuilder.CreateIndex(
                name: "IX_ParaleljaNxenesi_ParaleljaId",
                table: "ParaleljaNxenesi",
                column: "ParaleljaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParaleljaNxenesi");

            migrationBuilder.AddColumn<Guid>(
                name: "ParaleljaId",
                table: "SmnUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmnUser_ParaleljaId",
                table: "SmnUser",
                column: "ParaleljaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmnUser_Paralelja_ParaleljaId",
                table: "SmnUser",
                column: "ParaleljaId",
                principalTable: "Paralelja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
