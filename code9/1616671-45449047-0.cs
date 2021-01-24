    public class Polygonn
        {
            public List<List<double>> points { get; set; }
            public string type { get; set; }
        }
        public class RootObject
        {
            public double z { get; set; }
            public List<Polygonn> polygons { get; set; }
        }
 
    string data = System.IO.File.ReadAllText("backup.json");
     RootObject json = JsonConvert.DeserializeObject<RootObject>(data);
     json.polygons[polygon].points[0].ElementAt(0)
