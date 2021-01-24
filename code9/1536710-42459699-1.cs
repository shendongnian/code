        public class JsonQuestion
        {
            private List<JsonQuestion> container;
            public int id { get; set; }
            public string answer { get; set; }
            public string question { get; set; }
            public int value { get; set; }
            public JsonQuestion()
            {
                
            }
            public JsonQuestion(string categoryId, int value)
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString("http://jservice.io/api/clues?category=" + categoryId + "&value=" + value);
                    var container = JsonConvert.DeserializeObject<List<JsonQuestion>>(json);
                }
            }
            public DataContainer GetQuestions()
            {
                return new DataContainer
                {
                    Questions = container,
                };
            }
        }
        public class DataContainer
        {
            public List<JsonQuestion> Questions { get; set; }
        }
