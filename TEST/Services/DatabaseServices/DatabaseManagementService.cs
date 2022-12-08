using Microsoft.EntityFrameworkCore;
using TEST.Data;

namespace TEST.Services.DatabaseServices
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitializer(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<QuomodoDbContext>().Database.Migrate();
            }
        }
    }
}
