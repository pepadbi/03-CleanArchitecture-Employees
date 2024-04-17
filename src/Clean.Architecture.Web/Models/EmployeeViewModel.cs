namespace Clean.Architecture.Web.Models;

public class EmployeeViewModel
{
  public int Id { get; set; }
  public string FirstName { get; set; } = string.Empty; // Nastavíme výchozí hodnotu
  public string LastName { get; set; } = string.Empty;  // Nastavíme výchozí hodnotu
}
