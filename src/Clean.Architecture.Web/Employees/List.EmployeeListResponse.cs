using Clean.Architecture.Web.Employees;

namespace Clean.Architecture.Web.Employees;

public class EmployeeListResponse
{
  public List<EmployeeRecord> Employees { get; set; } = [];
}
