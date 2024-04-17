using Clean.Architecture.UseCases.Employees;

namespace Clean.Architecture.UseCases.Contributors.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListEmployeesQueryService
{
  Task<IEnumerable<EmployeeDTO>> ListAsync();
}
