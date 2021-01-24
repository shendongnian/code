    class Program {
        public static void Main() {
            var table = new DatabaseTable();
            var str = table.ConnectionString;
        }
    }
    public class DatabaseTable {
        public string ConnectionString = "test";
    }
