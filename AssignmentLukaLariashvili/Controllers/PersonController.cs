using AssignmentLukaLariashvili.Bal.Services;
using AssignmentLukaLariashvili.Bal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentLukaLariashvili.Api.Controllers;

[Route("api/[controller]")]

public class PersonController : Controller
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddPerson([FromBody] PersonCreateDto model)
    {
        var response = await _personService.AddPersonAsync(model);
        return Ok(response);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> EditPerson([FromBody] PersonEditDto model)
    {
        await _personService.EditPersonAsync(model);
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeletePerson([FromBody] int personId)
    {
        await _personService.DeletePerson(personId);
        return Ok();
    }

    [HttpPost("get-by-id")]
    public async Task<IActionResult> GetPersonById([FromBody] int id)
    {
        var response = await _personService.GetPersonById(id);
        return Ok(response);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllPersonsAsync()
    {
        var response = await _personService.GetPersonsAsync();
        return Ok(response);
    }
}
