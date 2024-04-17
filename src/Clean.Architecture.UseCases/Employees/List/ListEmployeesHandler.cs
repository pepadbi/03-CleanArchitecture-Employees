using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.UseCases.Contributors.List;
using Clean.Architecture.UseCases.Employees.List;

namespace Clean.Architecture.UseCases.Employees.List;

public class ListEmployeesHandler(IListEmployeesQueryService _query)
  : IQueryHandler<ListEmployeesQuery, Result<IEnumerable<EmployeeDTO>>>
{
  public async Task<Result<IEnumerable<EmployeeDTO>>> Handle(ListEmployeesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
