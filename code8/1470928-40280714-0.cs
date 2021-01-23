    public class Data
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    // ...
    var test2 = @"[{firstName: ""Sample First Name"", lastName: ""Sample Last Name""},{firstName: ""Sample First Name 2"", lastName: ""Sample Last Name 2""}]";
    var objects = JsonConvert.DeserializeObject<List<Data>>(test2);
