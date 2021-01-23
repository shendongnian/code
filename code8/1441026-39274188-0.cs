    public class POC
    {
      public int Id { get; set; }
      public string Desc { get; set; }
    }
    static List<POC> GetPOCOs()
    {
      return new List<POC>
      {
          new POC { Id = 1, Desc = "John"},
          new POC { Id = 2, Desc = "Jane" },
          new POC { Id = 3, Desc = "Joey" }
      };
    }
    
    static void Main(string[] args)
    {
      var pocos = GetPOCOs();
      var serializer = new JavaScriptSerializer();
      var sjson = serializer.Serialize(pocos);
      var djson = serializer.Deserialize<List<POC>>(sjson);
      Console.ReadLine();
    }
