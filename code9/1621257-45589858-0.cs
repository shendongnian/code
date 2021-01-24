    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DatabaseContext context = new DatabaseContext();
        private IDepartmentRepository departmentRepository;
        private ICustomerRepository customerRepository;
        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new DepartmentRepository(context);
                }
                return departmentRepository;
            }
        }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new CustomerRepository(context);
                }
                return customerRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
