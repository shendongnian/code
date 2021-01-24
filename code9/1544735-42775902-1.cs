    public class AgregateEmployeeRepository
    {
       private IEnumerable<IEmployeeRepository> _repositories;
    
       public AgregateEmployeeRepository(...)
       {
          // Can be injected manually or with an IoC...
       }
    
       void Save(Employee employee)
       {
          foreach(IEmployeeRepository repo in _repositories)
          {
             _repos.save(employee);
          }
       }
    }
