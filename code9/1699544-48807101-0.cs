    using Newtonsoft.Json;
    using System;
    
    static class P
    {
        static void Main()
        {
            var json = @"[ { ""Name"":""Fred"" }, { ""Name"":""Wilma"" } ]";
            var people = DeserializeJson<People[]>(json);
    
            foreach(var person in people)
            {
                Console.WriteLine(person.Name);
            }
        } 
        public static T DeserializeJson<T>(string Json)
        {
            if (CanDesirialize(Json))
            {
                return JsonConvert.DeserializeObject<T>(Json);
            }
    
            return (T)new object(); // note: this is bad and will never work
        }
    
        private static bool CanDesirialize(string json) => true;
    }
    public class People
    {
        public string Name { get; set; }
    }
