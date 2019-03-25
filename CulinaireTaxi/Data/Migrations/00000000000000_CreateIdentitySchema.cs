using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CulinaireTaxi.Data.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            // Normale user
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 450, nullable: false),
                    FirstName = table.Column<string>(maxLength: 256, nullable: true),
                    Prefix = table.Column<string>(maxLength: 256, nullable: true),
                    LastName = table.Column<string>(maxLength: 256, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 256, nullable: true),
                    HouseNumber = table.Column<string>(maxLength: 256, nullable: true),
                    HouseNumberPrefix = table.Column<string>(maxLength: 256, nullable: true),
                    City = table.Column<string>(maxLength: 256, nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Restaurant
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerId = table.Column<string>(maxLength: 450, nullable: false),
                    RestaurantName = table.Column<string>(maxLength: 256, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 256, nullable: true),
                    HouseNumber = table.Column<string>(maxLength: 256, nullable: true),
                    HouseNumberPrefix = table.Column<string>(maxLength: 256, nullable: true),
                    City = table.Column<string>(maxLength: 256, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurant_AspNetUsers_UserId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Tafels van een restaurant
            migrationBuilder.CreateTable(
                name: "RestaurantTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RestaurantId = table.Column<int>(nullable: false),
                    Available = table.Column<string>(maxLength: 256, nullable: true),
                    TableNumber = table.Column<string>(maxLength: 256, nullable: true),
                    NumberOfChairs = table.Column<string>(maxLength: 256, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantTable_Id",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Taxibedrijf
            migrationBuilder.CreateTable(
                name: "TaxiCompany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerId = table.Column<string>(maxLength: 450, nullable: false),
                    CompanyName = table.Column<string>(maxLength: 256, nullable: true),
                    CompanyLocation = table.Column<string>(maxLength: 256, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxiCompany_AspNetUsers_UserId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Taxi's bij een taxibedrijf
            migrationBuilder.CreateTable(
                name: "TaxiCompanyAvailable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaxiCompanyId = table.Column<int>(nullable: false),
                    TaxiAvailable = table.Column<bool>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiCompanyAvailable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxiCompany_Id",
                        column: x => x.TaxiCompanyId,
                        principalTable: "TaxiCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Contracten tussen taxi's en restauranten.
            migrationBuilder.CreateTable(
                name: "TaxiRestaurantContract",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false),
                    TaxiCompanyId = table.Column<int>(nullable: false),
                    ContractDescription = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TaxiRestaurantContract_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);

                    table.ForeignKey(
                        name: "FK_TaxiRestaurantContract_TaxiCompanyId",
                        column: x => x.TaxiCompanyId,
                        principalTable: "TaxiCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            // Reservaties tussen de user en restaurant
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false),
                    UserInfoId = table.Column<int>(nullable: false),
                    AnmountOfPersons = table.Column<int>(nullable: true),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Reservation_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);

                    table.ForeignKey(
                        name: "FK_Reservation_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            // Reservaties tussen de user en restaurant
            migrationBuilder.CreateTable(
                name: "TaxiReservations",
                columns: table => new
                {
                    TaxiCompanyId = table.Column<int>(nullable: false),
                    UserInfoId = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TaxiReservations_TaxiCompany",
                        column: x => x.TaxiCompanyId,
                        principalTable: "TaxiCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);

                    table.ForeignKey(
                        name: "FK_TaxiReservations_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
