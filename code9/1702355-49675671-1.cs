    [JsonConverter(typeof(PersonConverter))]
    public class PersonName
    {
        public PersonName(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
