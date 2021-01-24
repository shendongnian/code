    public class ApplicationDbContext :IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext() :
            base("Server=.;Initial Catalog=TestDb;Integrated Security=true;MultipleActiveResultSets=True;")
        {
        }
       public DbSet<Person> Peoples { get; set; }
       // add poco classes here
    }
