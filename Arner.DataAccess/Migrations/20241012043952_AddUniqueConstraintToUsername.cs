﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arner.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Username",
                table: "Users",
                column: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Username",
                table: "Users");
        }
    }
}
