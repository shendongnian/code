    public class Organization
    {
      public Guid Id { get; set; }
    }
    public class Employee
    {
      public Guid Id { get; set; }
      public Guid OrganizationId { get; set; }
      public Organization Organization { get; set; }
    }
    public Employee GetEmployeeWithOrganization(guid id)
    {
      var result = _context.Employees
        .Include(e => e.Organization)
        .FirstOrDefault(e => e.Id = id);
    }
