using AssignmentLukaLariashvili.Dal.Repositories;

namespace AssignmentLukaLariashvili.Dal;

public interface IUnitOfWork
{
    public IPersonRepository PersonRepository { get; }
    Task<int> SaveChangeAsync();
}

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private AssignmentDbContext _context;

    public UnitOfWork(AssignmentDbContext context)
    {
        _context = context;
    }

    public IPersonRepository PersonRepository => new PersonRepository(_context);

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
