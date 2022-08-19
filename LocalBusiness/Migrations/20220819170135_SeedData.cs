using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalBusiness.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "BusinessId", "Address", "Name", "Phone", "Type" },
                values: new object[,]
                {
                    { 1, "1 Technology Dr, Irvine, Ca 92618", "Pho Love", "6267778888", "Restaurant" },
                    { 2, "123 Alton Parkway, Irvine, Ca 92618", "Four Sea Restaurant", "4434425678", "Restaurant" },
                    { 3, "45 Jaboree Road, Irvine, Ca 92618", "Duke Bakery", "8883332345", "Restaurant" },
                    { 4, "166 Alliance Ave, Tustin Ca 92780", "TjMax", "9098885643", "Shop" },
                    { 5, "678 Tomson Street, Tustin Ca 92780", "Mayce", "9092226789", "Shop" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Business",
                keyColumn: "BusinessId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Business",
                keyColumn: "BusinessId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Business",
                keyColumn: "BusinessId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Business",
                keyColumn: "BusinessId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Business",
                keyColumn: "BusinessId",
                keyValue: 5);
        }
    }
}
