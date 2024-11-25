using CMCS.Data;
using Microsoft.EntityFrameworkCore;

namespace Contract_Monthly_Claim_System
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Or your specific database provider

            var app = builder.Build();

            // Example of retrieving approved claims
            using (var scope = app.Services.CreateScope())
            {
                // Resolve ApplicationDbContext from the DI container
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Check if 'approvedClaims' is declared and initialized before using
                var approvedClaims = context.Claims.Where(c => c.Status == "Approved").ToList();

                // Optional: Output the result for debugging/logging
                if (approvedClaims.Any())
                {
                    Console.WriteLine("Approved Claims:");
                    foreach (var claim in approvedClaims)
                    {
                        Console.WriteLine($"Claim ID: {claim.Id}, Status: {claim.Status}");
                    }
                }
                else
                {
                    Console.WriteLine("No approved claims found.");
                }
            }

            // Middleware pipeline configuration
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Endpoint configuration
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}