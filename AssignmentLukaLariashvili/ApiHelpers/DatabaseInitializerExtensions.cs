using AssignmentLukaLariashvili.Dal;

namespace AssignmentLukaLariashvili.Api.ApiHelpers;

public static class DatabaseInitializerExtensions
{
    public static void InitializeDatabase(this IServiceCollection services)
    {
        var buildServiceProvider = services.BuildServiceProvider();
        if (!(buildServiceProvider.GetService(typeof(AssignmentDbContext)) is AssignmentDbContext famousQuoteQuizDbContext)) return;
        famousQuoteQuizDbContext.Database.EnsureCreated();
        famousQuoteQuizDbContext.Dispose();
    }
}