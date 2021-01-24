    // Define the class / model
    public class MyNewClass {
    // Case sensitive vvv to match your Json
        public string map {get; set;}
        public DataTable areas {get; set;}
        // you can have several constructor methods defined, I show the usage for each below.
        public MyNewClass() {}
        public MyNewClass(string countryMap, DataTable table) {
            map = countryMap;
            areas = table;
        }
    }
