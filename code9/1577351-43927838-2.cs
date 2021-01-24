    public interface ITestable
    {
        Func<string, bool> Predicate { get; }
    }
    public class Admission : ITestable
    {
        ...other members...
        public Person Person { get; }
        public Expression<Func<string, bool>> Predicate =>
            x => Person.Predicate(x);
    }
    public class Person : ITestable
    {
        ...other members...
        public Expression<Func<string, bool>> Predicate =>
            x => string.IsNullOrEmpty(x) || FirstName.Contains(x) || LastName.Contains(x);
    }
    // No longer needed, just operate from the Predicate property.
    public static Expression<Func<ITestable, bool>> SearchITestable(string searchTerm)    
    { 
        if(string.IsNullOrEmpty(searchTerm)) 
        { 
             return a => true; 
        }
 
        return a => a.Predicate(searchTerm);
    }
