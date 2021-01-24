    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    var obj = JsonConvert.DeserializeObject<List<Person>>(ar);
    foreach (var person in obj)
    {
        Console.WriteLine(
            string.Format("id:{0}, name:{1}",
                            person.Id,
                            person.Name));
    }
