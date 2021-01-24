    public class Person
    {
        // C# 3.0 auto-implemented properties
        public string   Name     { get; set; }
        public int      Age      { get; set; }
        public DateTime Birthday { get; set; }
    }
    public class Example{
        public static void JsonToPerson()
        {
        string json = @"
            {
                ""Name""     : ""Thomas More"",
                ""Age""      : 57,
                ""Birthday"" : ""02/07/1478 00:00:00""
            }";
    
        Person thomas = JsonMapper.ToObject<Person>(json);
    
        thomas.Age = 23;
    
        string newJson = JsonMapper.ToJson(thomas);
        }
    }
