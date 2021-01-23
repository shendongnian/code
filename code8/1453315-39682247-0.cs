    public interface IFilterStrategy<T> 
    {
        IQueryable<T> Filter(Filter filter, IQueryable<T> query);
    }
    
    public class FilterContacts : IFilterStrategy<SomeClass>
    {
         public IQueryable<T> Filter(Filter filter, IQueryable<T> query)
    	 {
    	    if (filter.Contacts != null && filter.Contacts.Any())
            {
                result = result.Where(x => filter.Contacts.Contains(x.ContactID));
            }
    
            return result;
    	 }
    }
    
    
    public class FilterSomethingElse : IFilterStrategy<SomeClass>
    {
         public IQueryable<T> Filter(Filter filter, IQueryable<T> query)
    	 {
    	    if (filter.SomethingElse != null && filter.SomethingElse.Any())
            {
                result = result.Where(x => filter.SomethingElse.Contains(x.SomethingElseID));
            }
    	 }
    	 
    }
