    using Newtonsoft.Json;
    using System;    
    class P {
        static void Main() {
            var obj = new P(@"[ { ""Name"":""Fred"" }, { ""Name"":""Wilma"" } ]");
            var people = obj.ExecuteService<People[]>();
            foreach (var person in people) {
                Console.WriteLine(person.Name);
            }
        }
        public P(string rslt) { this.rslt = rslt; }
        private readonly string rslt;
        public T ExecuteService<T>()
        {
            // call service
            return DeserializeJson<T>(rslt);
        }
    
        public static T DeserializeJson<T>(string Json)
        {
            if (CanDesirialize(Json))
            {
                return JsonConvert.DeserializeObject<T>(Json);
            }
    
            return (T)new object();
        }
    
        private static bool CanDesirialize(string json) => true;
    }
    public class People {
        public string Name { get; set; }
    }
