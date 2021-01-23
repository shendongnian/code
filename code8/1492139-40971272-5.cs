    public class LibraryContext : DbContext, ILibraryContext
    {
        public LibraryContext() : base("DefaultConnection")
        {
        }
        // other methods here
    }
    public class AuthorRepository : IDisposable, IAuthorRepository
    {
        private ILibraryContext context;
        // the context will be injected and should not be provided by the caller, if DI is used
        public AuthorRepository(ILibraryContext context)
        {
            this.context = context;
        }
        // other methods come here
    }
    public class AuthorController : Controller
    {
        // this allows for automatic injection based on defined bindings
        [Inject]
        public IAuthorRepository authorRepository { get; set; }
        public AuthorController()
        {
            // no need for this, as DI takes care of the initialization
            // also, controller does not have to know about your data access classes
            // this.authorRepository = new AuthorRepository(new LibraryContext());
        }
        public ActionResult Index()
        {
            var authors = authorRepository.GetAuthors();
            return View(authors);
        }
    }
