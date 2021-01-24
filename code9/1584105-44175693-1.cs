    public class SomeClass
    {
        private readonly IMyRepository _myRepository;
        private readonly IMyOtherRepository _myOtherRepository;
        public SomeClass(IMyRepository myRepository, IMyOtherRepository myOtherRepository)
        {
            _myRepository = myRepository;
            _myOtherRepository = myOtherRepository;
        }
        public string SayHello()
        {
            return $"Hello from {_myRepository.ContextName()}  and {_myOtherRepository.ContextName()}";
        }
    }
    public interface IMyOtherRepository
    {
        string ContextName();
    }
    public interface IMyRepository
    {
        string ContextName();
    }
    public class MyContext : DbContext
    {
        // Code
    }
    public class MyOtherContext : DbContext
    {
        // Code
    }
    public class MyRepository : IMyRepository
    {
        private readonly IEnumerable<Meta<DbContext>> _context;
        public MyRepository(IEnumerable<Meta<DbContext>> context)
        {
            _context = context;
            // Code
        }
        public string ContextName() => _context.First(x => x.Metadata["EFContext"].Equals("My")).Value.GetType().Name;
    }
    public class MyOtherRepository : IMyOtherRepository
    {
        private readonly IEnumerable<Meta<DbContext>> _context;
        public MyOtherRepository(IEnumerable<Meta<DbContext>> context)
        {
            this._context = context;
            // Code
        }
        public string ContextName() => _context.First(x => x.Metadata["EFContext"].Equals("Other")).Value.GetType().Name;
    }
