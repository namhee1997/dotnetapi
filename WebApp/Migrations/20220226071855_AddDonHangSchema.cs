﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddDonHangSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getutcdate()"),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrangDonHang = table.Column<int>(type: "int", nullable: false),
                    NguoiNhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChiGiao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDh);
                });

            migrationBuilder.CreateTable(
                name: "DonHangChiTiet",
                columns: table => new
                {
                    MaHh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    GiamGia = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangChiTiet", x => new { x.MaDh, x.MaHh });
                    table.ForeignKey(
                        name: "FK_DonHangChiTiet_DonHang",
                        column: x => x.MaDh,
                        principalTable: "DonHang",
                        principalColumn: "MaDh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangChiTiet_HangHoa",
                        column: x => x.MaDh,
                        principalTable: "HangHoa",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHangChiTiet");

            migrationBuilder.DropTable(
                name: "DonHang");
        }
    }
}