    public class Videogame
    {
        [JsonProperty("@name")]
        public string Name { get; set; }
    
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
    }
    
    class MainClass
    {
        public static void Main(string[] args)
        {
            var obj = new Videogame();
            obj.Name = "MyName";
            obj.ReleaseDate = DateTime.Now;
            string str= JsonConvert.SerializeObject(obj);
            Console.WriteLine(str);
        }
    }
