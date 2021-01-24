    public interface ITestable
    {
        Func<string, bool> Predicate { get; }
    }
    public class Admission : ITestable
    {
        ...other members...
        public Func<string, bool> Predicate =>
            x => Person.FirstName.Contains(x) || Person.LastName.Contains(x);
    }
    public class Person : ITestable
    {
        ...other members...
        public Func<string, bool> Predicate =>
            x => FirstName.Contains(x) || LastName.Contains(x);
    }
    public static Expression<Func<ITestable, bool>> SearchITestable(string searchTerm)    
    { 
        if(string.IsNullOrEmpty(searchTerm)) 
        { 
             return a => true; 
        }
 
        return a => a.Predicate(searchTerm);
    }
