using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Infrastructure.Data;

namespace Clean.Architecture.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
  private readonly AppDbContext _dbContext;

  public EmployeeRepository(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
  {
    return await _dbContext.Employees.ToListAsync();
  }
}
