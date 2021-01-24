    public interface ITestable
    {
        Func<string, bool> Predicate { get; }
    }
    public class Admission : ITestable
    {
        // ...other members...
        public Person Person { get; }
        public Expression<Func<string, bool>> Predicate =>
            x => Person.Predicate(x);
    }
    public class Person : ITestable
    {
        // ...other members...
        public Expression<Func<string, bool>> Predicate =>
            x => string.IsNullOrEmpty(x) || FirstName.Contains(x) || LastName.Contains(x);
    }
    // The calling code:
    IQueryable<ITestable> people =
        source.Where(x => x.Predicate(searchTerm));
