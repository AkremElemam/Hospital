using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorsAndPatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "ImageUrl", "IsActive", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, null, true, "Dr. Ahmed Ali", "Cardiology" },
                    { 2, null, true, "Dr. Ramy Hassan", "Dermatology" },
                    { 3, null, true, "Dr. Youssef Adel", "Neurology" },
                    { 4, null, true, "Dr. Reda Kamal", "Pediatrics" },
                    { 5, null, true, "Dr. Karim Nabil", "Orthopedics" },
                    { 6, null, true, "Dr. Hany Mostafa", "General Surgery" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientId", "Name", "PhoneNumber", "RegisteredOn" },
                values: new object[,]
                {
                    { 1, "Mohamed Saeed", null, new DateTime(2025, 9, 30, 14, 37, 44, 30, DateTimeKind.Utc).AddTicks(6229) },
                    { 2, "Sara Ali", null, new DateTime(2025, 9, 30, 14, 37, 44, 30, DateTimeKind.Utc).AddTicks(6491) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientId",
                keyValue: 2);
        }
    }
}
