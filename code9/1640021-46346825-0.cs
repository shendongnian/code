    public class Employee
    {
    }
    public class User
    {
    }
    public interface IRepo<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        DbSet<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        DbContext GetContext();
    }
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        DbContext _context;
        public TEntity Get(int id)
        {
            return _context.Set<TEntity>()
                           .Find(id);
        }
        public DbSet<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>();
        }
        public DbContext GetContext()
        {
            return _context;
        }
    }
    public static class RepoExtensions
    {
        public static ChangeTracker DoMagic(this Repo<User> userRepo)
        {
            return userRepo.GetContext().ChangeTracker;
        }
    }
    public static class Test
    {
        public static void DoTest()
        {
            Repo<User> repoUser = new Repo<User>();
            repoUser.DoMagic();
            Repo<Employee> repoEmployee = new Repo<Employee>();
            //repoEmployee.DoMagic();
        }
    }
