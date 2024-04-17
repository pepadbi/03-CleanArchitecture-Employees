using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.UseCases.Employees;

namespace Clean.Architecture.UseCases.Employees.List;

public record ListEmployeesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<EmployeeDTO>>>;
