using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMN.Data.Migrations
{
    public partial class db_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ligjerata",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Emri = table.Column<string>(nullable: true),
                    File = table.Column<byte[]>(nullable: true),
                    MesuesiId = table.Column<Guid>(nullable: false),
                    LendaId = table.Column<Guid>(nullable: false),
                    ParaleljaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligjerata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mungesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MeArsyje = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Arsyeja = table.Column<string>(nullable: true),
                    LendaId = table.Column<Guid>(nullable: false),
                    NxenesiID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mungesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Vleresimi = table.Column<int>(nullable: false),
                    LendaId = table.Column<Guid>(nullable: false),
                    NxenesiId = table.Column<Guid>(nullable: false),
                    MesuesiId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orari",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Dita = table.Column<string>(nullable: true),
                    Ora = table.Column<string>(nullable: true),
                    ParaleljaID = table.Column<Guid>(nullable: false),
                    MesuesiID = table.Column<Guid>(nullable: false),
                    LendaID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmnUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdentityId = table.Column<string>(nullable: true),
                    Emri = table.Column<string>(nullable: true),
                    EmriPrindit = table.Column<string>(nullable: true),
                    Mbiemri = table.Column<string>(nullable: true),
                    DataELindjes = table.Column<DateTime>(nullable: false),
                    Foto = table.Column<byte[]>(nullable: true),
                    ParaleljaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmnUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmnUser_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmriLendes = table.Column<string>(nullable: true),
                    MesuesiId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lenda_SmnUser_MesuesiId",
                        column: x => x.MesuesiId,
                        principalTable: "SmnUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Paralelja",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Klasa = table.Column<string>(nullable: true),
                    VitiShkollor = table.Column<string>(nullable: true),
                    NumriParaleles = table.Column<int>(nullable: false),
                    KujdestariId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paralelja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paralelja_SmnUser_KujdestariId",
                        column: x => x.KujdestariId,
                        principalTable: "SmnUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Foto = table.Column<byte[]>(nullable: true),
                    Titulli = table.Column<string>(nullable: true),
                    Pershkrimi = table.Column<string>(nullable: true),
                    MesuesiId = table.Column<Guid>(nullable: false),
                    SekretariId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_SmnUser_MesuesiId",
                        column: x => x.MesuesiId,
                        principalTable: "SmnUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Post_SmnUser_SekretariId",
                        column: x => x.SekretariId,
                        principalTable: "SmnUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lenda_MesuesiId",
                table: "Lenda",
                column: "MesuesiId");

            migrationBuilder.CreateIndex(
                name: "IX_Ligjerata_LendaId",
                table: "Ligjerata",
                column: "LendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ligjerata_MesuesiId",
                table: "Ligjerata",
                column: "MesuesiId");

            migrationBuilder.CreateIndex(
                name: "IX_Ligjerata_ParaleljaId",
                table: "Ligjerata",
                column: "ParaleljaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mungesa_LendaId",
                table: "Mungesa",
                column: "LendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mungesa_NxenesiID",
                table: "Mungesa",
                column: "NxenesiID");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_LendaId",
                table: "Nota",
                column: "LendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_MesuesiId",
                table: "Nota",
                column: "MesuesiId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_NxenesiId",
                table: "Nota",
                column: "NxenesiId");

            migrationBuilder.CreateIndex(
                name: "IX_Orari_LendaID",
                table: "Orari",
                column: "LendaID");

            migrationBuilder.CreateIndex(
                name: "IX_Orari_MesuesiID",
                table: "Orari",
                column: "MesuesiID");

            migrationBuilder.CreateIndex(
                name: "IX_Orari_ParaleljaID",
                table: "Orari",
                column: "ParaleljaID");

            migrationBuilder.CreateIndex(
                name: "IX_Paralelja_KujdestariId",
                table: "Paralelja",
                column: "KujdestariId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_MesuesiId",
                table: "Post",
                column: "MesuesiId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SekretariId",
                table: "Post",
                column: "SekretariId");

            migrationBuilder.CreateIndex(
                name: "IX_SmnUser_IdentityId",
                table: "SmnUser",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_SmnUser_ParaleljaId",
                table: "SmnUser",
                column: "ParaleljaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ligjerata_SmnUser_MesuesiId",
                table: "Ligjerata",
                column: "MesuesiId",
                principalTable: "SmnUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ligjerata_Lenda_LendaId",
                table: "Ligjerata",
                column: "LendaId",
                principalTable: "Lenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ligjerata_Paralelja_ParaleljaId",
                table: "Ligjerata",
                column: "ParaleljaId",
                principalTable: "Paralelja",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Mungesa_SmnUser_NxenesiID",
                table: "Mungesa",
                column: "NxenesiID",
                principalTable: "SmnUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Mungesa_Lenda_LendaId",
                table: "Mungesa",
                column: "LendaId",
                principalTable: "Lenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_SmnUser_MesuesiId",
                table: "Nota",
                column: "MesuesiId",
                principalTable: "SmnUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_SmnUser_NxenesiId",
                table: "Nota",
                column: "NxenesiId",
                principalTable: "SmnUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Lenda_LendaId",
                table: "Nota",
                column: "LendaId",
                principalTable: "Lenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orari_SmnUser_MesuesiID",
                table: "Orari",
                column: "MesuesiID",
                principalTable: "SmnUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orari_Lenda_LendaID",
                table: "Orari",
                column: "LendaID",
                principalTable: "Lenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orari_Paralelja_ParaleljaID",
                table: "Orari",
                column: "ParaleljaID",
                principalTable: "Paralelja",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SmnUser_Paralelja_ParaleljaId",
                table: "SmnUser",
                column: "ParaleljaId",
                principalTable: "Paralelja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paralelja_SmnUser_KujdestariId",
                table: "Paralelja");

            migrationBuilder.DropTable(
                name: "Ligjerata");

            migrationBuilder.DropTable(
                name: "Mungesa");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Orari");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Lenda");

            migrationBuilder.DropTable(
                name: "SmnUser");

            migrationBuilder.DropTable(
                name: "Paralelja");
        }
    }
}
