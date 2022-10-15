using AssignmentLukaLariashvili.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentLukaLariashvili.Dal.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person> GetPersonById(int personId);
}

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(AssignmentDbContext context) : base(context)
    {
    }
    public async Task<Person> GetPersonById(int personId)
    {
        return await DataBaseContext.Persons.SingleOrDefaultAsync(x => x.Id == personId);
    }
}
