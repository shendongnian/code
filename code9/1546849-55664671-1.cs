         public interface IUserRepository : IRepository<User>
         {
           //Also you can add here another methods according to your needs
         }
         public class UserRepository : EfRepository<User>,IUserRepository
         {
                public UserRepository(YourDbContext yourDbContext) : base(yourDbContext)
                {
        
                }
         }
