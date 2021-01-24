    class Program
    {
        static void Main(string[] args)
        {
            
            var result = new Program().GetMyClassList();
            foreach (var item in result)
                Console.WriteLine($"ID: {item.Id}\tAmount:{item.Amount}");
            Console.ReadKey();
        }
        public List<MyClass> GetMyClassList()
        {
            List<MyClass> myClassList = new List<MyClass>();
            string responseText = "{\"GetMyClassListResult\":{\"MyClassList\":[{\"Id\":1,\"Amount\":\"5,00\"},{\"Id\":2,\"Amount\":\"10,00\"},{\"Id\":3,\"Amount\":\"20,00\"},{\"Id\":4,\"Amount\":\"25,00\"}],\"ReturnValues\":{\"ErrorCode\":1,\"ErrorDescription\":\"Successful\"}}}";
            myClassList = JsonConvert.DeserializeObject<RootObject>(responseText)
                           .GetMyClassListResult.MyClassList;
            return myClassList;
        }
    }
    public class MyClass
    {
        [JsonProperty("Id")]
        public Int64 Id { get; set; }
        [JsonProperty("Amount")]
        public string Amount { get; set; }
    }
    public class ReturnValues
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
    public class GetMyClassListResult
    {
        [JsonProperty("MyClassList")]
        public List<MyClass> MyClassList { get; set; }
        public ReturnValues ReturnValues { get; set; }
    }
    public class RootObject
    {
        public GetMyClassListResult GetMyClassListResult { get; set; }
    }
