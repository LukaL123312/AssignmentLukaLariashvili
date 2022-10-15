using AssignmentLukaLariashvili.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentLukaLariashvili.Dal;

public class AssignmentDbContext : DbContext
{
    public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
    public DbSet<Person> Persons { get; set; }
}
