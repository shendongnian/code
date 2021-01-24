    public class PostalCodeInfoTable{
        //.........
        private static PostalCodeInfoTable Instance = new PostalCodeInfoTable();
    
        private PostalCodeInfoTable() {
            db = new GetConnectionString();
        }
    
        public static PostalCodeInfoTable GetInstance() {
            return Instance;
        }
    }
