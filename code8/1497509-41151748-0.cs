    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ ""FirstName"":""Bob"" }";
    
            Person person = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(json);
    
            Console.WriteLine(person.FirstName);
        }
    
        public class Person
        {
            public string FirstName { get; set; }
        }
    }
