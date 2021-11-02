using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project_final_6013532.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientdata",
                columns: table => new
                {
                    clientDataId = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    mktId = table.Column<string>(nullable: true),
                    mktName = table.Column<string>(nullable: true),
                    telNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientdata", x => x.clientDataId);
                });

            migrationBuilder.CreateTable(
                name: "rejectAts",
                columns: table => new
                {
                    rejectAtsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    refCode = table.Column<string>(nullable: true),
                    clientDataId = table.Column<string>(nullable: true),
                    sendingBank = table.Column<string>(nullable: true),
                    sendingBankNo = table.Column<string>(nullable: true),
                    receivingBank = table.Column<string>(nullable: true),
                    receivingBankNo = table.Column<string>(nullable: true),
                    amount = table.Column<double>(nullable: false),
                    statusCode = table.Column<string>(nullable: true),
                    statusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rejectAts", x => x.rejectAtsId);
                    table.ForeignKey(
                        name: "FK_rejectAts_clientdata_clientDataId",
                        column: x => x.clientDataId,
                        principalTable: "clientdata",
                        principalColumn: "clientDataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rejectAts_clientDataId",
                table: "rejectAts",
                column: "clientDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rejectAts");

            migrationBuilder.DropTable(
                name: "clientdata");
        }
    }
}
