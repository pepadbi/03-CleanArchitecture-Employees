using Clean.Architecture.UseCases.Contributors.List;
using Clean.Architecture.UseCases.Employees;
using Clean.Architecture.UseCases.Employees.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;

public class ListEmployeesQueryService(AppDbContext _db) : IListEmployeesQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<EmployeeDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<EmployeeDTO>(
      $"SELECT Id, FirstName, LastName FROM Employees") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
