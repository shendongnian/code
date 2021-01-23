    class Program
    {
        static void Main(string[] args)
        {
            var Result = "[{\"CompanyID\":32,\"Roles\":[\"Admin\"]}]";
            var cList = JsonConvert.DeserializeObject<List<Company>>(Result);
            var obj = cList.First().CompanyID;
        }
    }
    
    public class Company
    {
        public int CompanyID { get; set; }
        public List<string> Roles { get; set; }
    }
