    // Define the class
    public class MyNewClass {
    // Case sensitive vvv to match your Json
        public string map {get; set;}
        public DataTable areas {get; set;}
        
        public MyNewClass() {}
        public MyNewClass(string countryMap, DataTable data) {
            map = countryMap;
            areas = data;
        }
    }
    // Instanciate the class
    var returnData = new MyNewClass("USA", yourDataTable);
    // or
    var returnData2 = new MyNewClass();
    returnData2.map = "USA";
    returnData2.areas = yourDataTable;
    // Finally serialize your object
    var yourJson = JSON.SerializeObject(returnData);
    // or
    var yourJosn2 = JSON.SerializeObject(returnData2);
