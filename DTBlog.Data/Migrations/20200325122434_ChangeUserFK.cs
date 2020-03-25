using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DTBlog.Data.Migrations
{
    public partial class ChangeUserFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    MailAddress = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsSuperAdmin = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    ChangedUserId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AuthorFullName = table.Column<string>(nullable: true),
                    AuthorBio = table.Column<string>(nullable: true),
                    AuthorImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Users_ChangedUserId",
                        column: x => x.ChangedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    ChangedUserId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    MusicLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musics_Users_ChangedUserId",
                        column: x => x.ChangedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    ChangedUserId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NewsTitle = table.Column<string>(nullable: false),
                    NewsContent = table.Column<string>(nullable: false),
                    NewsImage = table.Column<byte[]>(nullable: true),
                    NewsStatus = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Users_ChangedUserId",
                        column: x => x.ChangedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_News_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationModel",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    ChangedUserId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    QuoteContent = table.Column<string>(nullable: false),
                    QuoteFrom = table.Column<string>(nullable: false),
                    QuoteImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationModel_Users_ChangedUserId",
                        column: x => x.ChangedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationModel_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    ChangedUserId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PostTitle = table.Column<string>(nullable: false),
                    PostContent = table.Column<string>(nullable: false),
                    PostImage = table.Column<byte[]>(nullable: true),
                    PostStatus = table.Column<short>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_ChangedUserId",
                        column: x => x.ChangedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ChangedUserId",
                table: "Authors",
                column: "ChangedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_ChangedUserId",
                table: "Musics",
                column: "ChangedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_UserId",
                table: "Musics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_ChangedUserId",
                table: "News",
                column: "ChangedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ChangedUserId",
                table: "Posts",
                column: "ChangedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationModel_ChangedUserId",
                table: "QuotationModel",
                column: "ChangedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationModel_UserId",
                table: "QuotationModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "QuotationModel");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
