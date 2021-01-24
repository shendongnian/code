    public interface DbInterface {
    ... Generic method declaration
    }
    
    public class Mysql :db {
    ... Generic method implementation
    }
    
    public class Oracle :db {
    ... Generic method implementation
    }
    
    public class YourClass {
        private DbInterface _db;
        
        public YourClass(DbInterface db) {
           this._db = db;
        }
    }
