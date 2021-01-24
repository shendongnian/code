    [TestClass()]
    public class ConcreteText: TestBase
    {    
        private IMyDbContext _context;
        [TestInitialize]
        public new void Initialize()
        {
            base.Initialize();
            _context = MockRepository.GenerateMock<IMyDbContext>();
            _context.Stub(x => x.DbSetName).PropertyBehavior(); // Name of your dbset
            _context.DbSetName = GenerateSet(DbSetCollection); // Define a mock dbset collection
        }
     }
