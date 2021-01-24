    public class CustomerValidator: AbstractValidator<Customer>
    {
        private readonly IScoped<AppDbContext> scopedContext;
        protected AppDbContext DbContext { get } => scopedContext.Instance;
        public CustomValidator(IScoped<AppDbContext> scopedContext)
        {
            this.scopedContext = scopedContext ?? throw new ArgumentNullException(nameof(scopedContext));
            // Access DbContext via this.DbContext
        }
    }
