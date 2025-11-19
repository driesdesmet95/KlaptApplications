using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klapt.Event.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventTypeId",
                table: "EventItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventTypeId",
                table: "EventItems",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventItems_EventTypes_EventTypeId",
                table: "EventItems",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventItems_EventTypes_EventTypeId",
                table: "EventItems");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropIndex(
                name: "IX_EventItems_EventTypeId",
                table: "EventItems");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "EventItems");
        }
    }
}
