    public static void Main(string[] args)
    {
         string str = "Bbox(x1: 750; y1: 300; x2: 1100; y2: 600)".Replace("Bbox(", "{").Replace(")", "}").Replace(";", ",");
         Bbox box = JsonConvert.DeserializeObject<Bbox>(str);
    }
    class Bbox
    {
         public int x1;
         public int y1;
         public int x2;
         public int y2;
     }
