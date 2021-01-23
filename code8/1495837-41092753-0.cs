         class Show
    {
        public string title { get; set; }
        public string imdb_id { get; set; }
        public string epguide_name { get; set; }
    }
    class Episode
    {
        public Show show { get; set; }
        public string title { get; set; }
        public int number { get; set; }
        public int season { get; set; }
        public DateTime release_date { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient wc = new WebClient())
            {
                //download json string
                var json = wc.DownloadString("http://epguides.frecar.no/show/gameofthrones/");
                //convert json to dynamic object
                JObject obj = JObject.Parse(json);
                //create an array that have as many elements as the children of obj => {"1", "2", "3", ...}
                JArray[] results = new JArray[obj.Children().Count()];
                //fill the array with the children of obj => results[6] = "[{"show": {"title": "Game of Thrones", "imdb_id": "tt0944947", "epguide_name": "gameofthrones"}, "title": "TBA", "number": 1, "season": 7, "release_date": "2017-06-25"}]"
                for (int i = 0; i < results.Length; i++)
                {
                    results[i] = (JArray)obj[(i + 1).ToString()];
                }
                //deserialize each item in results to List<Episode> if you checked the response it returns arrays of episodes
                List<List<Episode>> seasons = new List<List<Episode>>(results.Length);
                foreach (var item in results)
                {
                    seasons.Add(JsonConvert.DeserializeObject<List<Episode>>(item.ToString()));
                }
                //output the result
                foreach (var season in seasons)
                {
                    foreach (var episod in season)
                    {
                        Console.WriteLine("Show: {0}, release date: {1}", episod.show.title, episod.release_date);
                    }
                }
                Console.ReadKey();
            }
        }
    }
