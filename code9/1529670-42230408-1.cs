    public class Repository : IRepository
    {
        IDbContext context;
        public Repository(IDbContext dbContext)
        {
            context = dbContext;
        }
        public void WriteCar(Car car)
        {
            context.WriteCar(car);
        }
    }
