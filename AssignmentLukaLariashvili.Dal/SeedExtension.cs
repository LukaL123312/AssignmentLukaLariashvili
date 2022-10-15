using AssignmentLukaLariashvili.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentLukaLariashvili.Dal;

public static class SeedExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var person1 = new Person() { Id = 1, Name = "Luka Lariashvili"};
        var person2 = new Person() { Id = 2, Name = "Luk Lal"};
        modelBuilder.Entity<Person>().HasData(person1, person2);
    }
}
