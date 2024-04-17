using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.UseCases.Employees.List;
using System.Threading.Tasks;
using Clean.Architecture.Web.Models;

namespace Clean.Architecture.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : Controller
{
  private readonly GetAllEmployees _getAllEmployees;

  public EmployeesController(GetAllEmployees getAllEmployees)
  {
    _getAllEmployees = getAllEmployees;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var employees = await _getAllEmployees.ExecuteAsync();
    return Ok(employees);
  }
  public async Task<IActionResult> Index()
  {
    var employees = await _getAllEmployees.ExecuteAsync();
    var viewModels = employees.Select(e => new EmployeeViewModel
    {
      Id = e.Id,
      FirstName = e.FirstName,
      LastName = e.LastName
    }).ToList();

    return View(viewModels);
  }
}
