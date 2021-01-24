    public class MyValues
    {
        [JsonProperty]
        Stuff Value
        {
            set
            {
                (Values = Values ?? new List<Stuff>(1)).Clear();
                Values.Add(value);
            }
        }
        public List<Stuff> Values { get; set; }
        public Thing Other { get; set; }
    }
