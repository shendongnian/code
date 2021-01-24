    public class FooRepository
        : ICollection<Foo>
        , INotifyCollectionChanged
    {
        private BarDbContext _context;
    
        public FooRepository()
        {
            _context = new BarDbContext();
            _context.Foos.Local.CollectionChanged += (o, e) => CollectionChanged(this, e);
        }
        //Delegate ICollection to _context.Foos.Local
        public Foo this[int index] { get { return _context.Foos.Local[index]; } }
    
        public Task Load(Expression<Foo, bool> predicate)
        {
            return _context.Foos.Where(predicate).LoadAsync();
        }
    }
