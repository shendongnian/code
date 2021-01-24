    public class EntityBase {}
    
    public interface ITagged
    {
        string TagIDs { get; }
    }
    public interface INamed
    {
        string Name { get; }
    }
    public class Book : EntityBase, ITagged, INamed
    {
        public string TagIDs { get; set; }
        public string Name { get; }
    }
    
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> ListAll();
    }
    public interface IQueryTags<T> where T : ITagged
    {
        IEnumerable<T> ListWithTags(Expression<Func<T, bool>> predicate);
    }
    public interface IQueryByName<T> where T : INamed
    {
        T GetByName(string name);
    }
    public interface IBookRepository : IRepository<Book>, IQueryTags<Book>, IQueryByName<Book>
    {
        
    }
    public class ConcreteBookRepository: IBookRepository
    {
        public IEnumerable<Book> ListAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Book> ListWithTags(Expression<Func<Book, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Book GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
