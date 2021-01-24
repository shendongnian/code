    class Program
    {
        static void Main(string[] args)
        {
            var json = "{\"SNumber\":\"05\",\"LName\":\"TyJ\",\"LNameMarkup\":\"18/TyJ\"}";
            var jsonCollection =
                "[{\"SNumber\":\"05\",\"LName\":\"TyJ\",\"LNameMarkup\":\"18/TyJ\"},\r\n{\"SNumber\":\"10\",\"LName\":\"TyJ2\",\"LNameMarkup\":\"20/TyJ\"}]";
            var jsonRootObject = "{ \"data\" : [{\"SNumber\":\"05\",\"LName\":\"TyJ\",\"LNameMarkup\":\"18/TyJ\"}, {\"SNumber\":\"10\",\"LName\":\"TyJ2\",\"LNameMarkup\":\"20/TyJ\"}]}";
            var data = JsonConvert.DeserializeObject<SNameDTO.Datum>(json);
            var dataCollection = JsonConvert.DeserializeObject<List<SNameDTO.Datum>>(jsonCollection);
            var rootObject = JsonConvert.DeserializeObject<SNameDTO.RootObject>(jsonRootObject);
        }
    }
    public class SNameDTO
    {
        public class Datum
        {
            public string SNumber { get; set; }
            public string LName { get; set; }
            public string LNameMarkup { get; set; }
        }
        public class RootObject
        {
            public List<Datum> data { get; set; }
        }
    }
