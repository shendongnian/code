    public class Rootobject
    {
        public Root[] root { get; set; }
    }
    public class Root
    {
        public Arr1[] arr1 { get; set; }
        public Arr2[] arr2 { get; set; }
    }
    public class Arr1
    {
        public string name { get; set; }
        public string age { get; set; }
    }
    public class Arr2
    {
        public string name { get; set; }
        public string age { get; set; }
    }
	
	Root root = JsonConvert.DeserializeObject<Rootobject>(json);
