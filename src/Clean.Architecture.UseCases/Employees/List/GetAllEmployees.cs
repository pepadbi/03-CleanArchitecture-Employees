using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.ContributorAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.Architecture.UseCases.Employees.List;

public class GetAllEmployees
{
  private readonly IEmployeeRepository _employeeRepository;

  public GetAllEmployees(IEmployeeRepository employeeRepository)
  {
    _employeeRepository = employeeRepository;
  }

  public async Task<IEnumerable<Employee>> ExecuteAsync()
  {
    return await _employeeRepository.GetAllEmployeesAsync();
  }
}
