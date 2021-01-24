    public class SimRepository : ISimRepository {
        public readonly IAppDbContextFactory factory;
        
        public SimRepository(IAppDbContextFactory factory) {
            this.factory = factory;
        }
    
        public void LatheIn() {
            using (AppDbContext db = factory.Create()) {
                //...use db
            }
        }
    }
