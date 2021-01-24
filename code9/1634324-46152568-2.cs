    public class DatabaseContext : DbContext {
    
        public DatabaseContext() 
            :base(new SQLiteConnection(@"Data Source=|DataDirectory|ComponentDatabase.sqlite"), true) {
            //...
        }
    
        //...
    }
