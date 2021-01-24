    public class User
    {
        public User(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["user"];
            name = (string) jUser["name"];
            teamname = (string) jUser["teamname"];
            email = (string) jUser["email"];
        }
        public string name { get; set; }
        public string teamname { get; set; }
        public string email { get; set; }
    }
    // Use
    private void Run()
    {
        string json = @"{""user"":{""name"":""asdf"",""teamname"":""b"",""email"":""c""}";
        User user = new User(json);
        Console.WriteLine("Name : " + user.name);
        Console.WriteLine("Teamname : " + user.teamname);
        Console.WriteLine("Email : " + user.email);
   
     }
