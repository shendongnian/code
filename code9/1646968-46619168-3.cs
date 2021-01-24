    class Dto
    {
        public string user_name { get; set; }
        public string password { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var json = @"
            {
                ""user_name"" : ""user"",
                ""password"" : ""12345"",
                ""other_property"" : ""here is the problem"",
                ""something_else"" : ""yeah...""
            }";
            json.ValidateNoUnknownProperties<Dto>();
        }
    }
