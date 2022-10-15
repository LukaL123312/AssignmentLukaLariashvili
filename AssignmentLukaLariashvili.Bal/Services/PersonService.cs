using AssignmentLukaLariashvili.Bal.ViewModels;
using AssignmentLukaLariashvili.Dal;
using AssignmentLukaLariashvili.Dal.Models;

namespace AssignmentLukaLariashvili.Bal.Services;

public interface IPersonService
{
    Task<int> AddPersonAsync(PersonCreateDto person);
    Task EditPersonAsync(PersonEditDto person);
    Task DeletePerson(int personId);
    Task<List<PersonViewModel>> GetPersonsAsync();
    Task<Person> GetPersonById(int id);
}

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> AddPersonAsync(PersonCreateDto model)
    {
        var person = new Person
        {
            Name = model.Name
        };

        await _unitOfWork.PersonRepository.AddAsync(person);
        return await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeletePerson(int personId)
    {
        var person = await _unitOfWork.PersonRepository.FindAsync(x => x.Id == personId);
        if (person == null)
        {
            throw new Exception("Person Not found");
        }

        _unitOfWork.PersonRepository.Remove(person);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task EditPersonAsync(PersonEditDto model)
    {
        var person = await _unitOfWork.PersonRepository.GetPersonById(model.Id);
        if (person == null)
        {
            throw new Exception("person Not found");
        }

        person.Name = model.Name;

        await _unitOfWork.PersonRepository.UpdateAsync(person);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<Person> GetPersonById(int id)
    {
        return await _unitOfWork.PersonRepository.GetPersonById(id);
    }

    public async Task<List<PersonViewModel>> GetPersonsAsync()
    {
        var persons = await _unitOfWork.PersonRepository.GetAllAsync();
        var result = persons.Select(x =>
            new PersonViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }
        ).ToList();
        return result;
    }
}
