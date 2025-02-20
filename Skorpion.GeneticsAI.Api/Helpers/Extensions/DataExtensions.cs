using Skorpion.GeneticsAI.Api.Data;

namespace Skorpion.GeneticsAI.Api.Helpers.Extensions
{
    public static class DataExtensions
    {
        public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}
