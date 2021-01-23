    public static class ServerWideData {
        private static Dictionary<string, Data> DataDictionary { get; set; } = new Dictionary<string, Data>();
        public static Data Get(string controllerName = "") { // Could optionally add a default with the area and controller name
            return DataDictionary[controllerName];
        }
        public static void Set(Data data, string name = "") {
            DataDictionary.Add(name, data);
        }
        public class Data {
            public string PropertyOne { get; set; } = "Value of PropertyOne!!";
            // Add anything here
        }
    }
