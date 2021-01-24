    public abstract class ActivityLogEntry
    {
       int Id { get; }
    }
    public EmployeeActivityLogEntry : ActivityLogEntry
    {
        Employee Employee {get;}
    }
    public DepartmentActivityLogEntry : ActivityLogEntry
    {
        Department Department {get;}
    }
