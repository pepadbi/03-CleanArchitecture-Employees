using Ardalis.Result;
using Clean.Architecture.UseCases.Employees;
using Clean.Architecture.UseCases.Employees.List;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.Employees;

/// <summary>
/// List all Contributors
/// </summary>
/// <remarks>
/// List all contributors - returns a ContributorListResponse containing the Contributors.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<EmployeeListResponse>
{
  public override void Configure()
  {
    Get("/Employees");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<EmployeeDTO>> result = await _mediator.Send(new ListEmployeesQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new EmployeeListResponse
      {
        Employees = result.Value.Select(e => new EmployeeRecord(e.Id, e.FirstName, e.LastName)).ToList()
      };
    }
  }
}
