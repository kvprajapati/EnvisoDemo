using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EnvisoDemo.web.DBModel
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Customer", NormalizedName = "Customer" }
            );
        }
    }
}
