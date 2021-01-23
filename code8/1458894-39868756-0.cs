        public class JsonClass
        {
            public string Country { get; set; }
            public List<string> States { get; set; }
        }
        static void Main(string[] args)
        {
            string json = @"{""Country"":""USA"",""States"":[""Chicago"",""Miami""]}";
            JsonClass className  = JsonConvert.DeserializeObject<JsonClass>(json);
            className.States.Remove("Miami");
            Console.WriteLine(JsonConvert.SerializeObject(className));
        }
