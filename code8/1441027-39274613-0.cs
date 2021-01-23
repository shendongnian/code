    public static Program {
    
        public static string ConnectionString { get; set; }
    
        void Main(string connectionString) {
             ConnectionString = connectionString;
        }
    
    }
    
    public class SomeOtherClass {
         public void SomeOtherMethod () {
             Program.ConnectionString = "new value";
         }
    }
