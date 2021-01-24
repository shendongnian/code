    public class SimRepository : ISimRepository {
        public readonly AppDbContext db;
        
        public SimRepository(AppDbContext db) {
            this.db = db;
        }
    
        public void LatheIn() {
            //...use db
        }
    }
