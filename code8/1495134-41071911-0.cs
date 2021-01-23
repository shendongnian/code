    public class Joke
    {
        public int Id;
        public string Setup;
        public string Punchline;
        public override string ToString()
        {
            return Setup + " " + Punchline;
        }
    }
    public static Joke GetJoke()
    {
        var request = HttpWebRequest.Create("http://dadjokegenerator.com/api/api.php?a=j&lt=r&vj=0");
        using (var response = request.GetResponse())
        {
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var jokeString = reader.ReadToEnd();
                    Joke[] jokes = JsonConvert.DeserializeObject<Joke[]>(jokeString);
                    return jokes.FirstOrDefault();
                }
            }
        }
    }
