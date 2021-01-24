    public class Movie
    {
        public string Year { get; set; }
        public string Title { get; set; }
        public string[] Genre { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string url = System.Net.WebUtility.UrlDecode("https://query.yahooapis.com/v1/public/yql?q=SELECT%20*%20FROM%20html%20WHERE%20url%3D%22http%3A%2F%2Fthemoviedb.org%2Fsearch%2Fmovie%3Fquery%3Dsplit%22%20%20AND%20xpath%3D%27%2F%2Fdiv%5B%40class%3D%22info%22%5D%27&format=json&callback=");
            HttpClient cl = new HttpClient();
            var response = cl.GetStringAsync(url).Result;
            JObject json = JObject.Parse(response);
            var movies = new List<Movie>();
            foreach (var pchild in json["query"]["results"]["div"])
            {
                // title
                var title = pchild["p"][0]["a"]["title"];
                var titleStr = title != null ? title.Value<string>() : string.Empty;
                // year
                var releaseDate = pchild["p"][1]["span"][0]["content"];
                string releaseYear = string.Empty;
                DateTime temp;
                if (releaseDate != null
                    && DateTime.TryParse(releaseDate.Value<string>(), System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                {
                    releaseYear = temp.Year.ToString();
                }
                // genres
                var genre = pchild["p"][1]["span"][1]["content"];
                var genreArr = genre != null
                                ? genre.Value<string>()
                                    .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(st => st.Trim())
                                    .ToArray()
                                : new string[0];
                movies.Add(
                    new Movie
                    {
                        Title = titleStr,
                        Year = releaseYear,
                        Genre = genreArr
                    });
            }
            // searching for the best match
            string titleFilter = "Split";
            string yearFilter = "2017";
            var genreFilter = new string[] { "Drama", "Thriller", "Action" };
            var bestMatches = movies
                                .OrderByDescending(m => m.Title == titleFilter)
                                .ThenByDescending(m => m.Year == yearFilter)
                                .ThenByDescending(m => m.Genre.Intersect(genreFilter).Count());
            // the best match
            var bestMatch = bestMatches.First();
            Console.WriteLine(bestMatch.Title);
            Console.WriteLine(bestMatch.Year);
            Console.WriteLine(string.Join(",", bestMatch.Genre));
            // all the movies already ordered
            //foreach (var movie in bestMatches)
            //{
            //    Console.WriteLine(movie.Title);
            //    Console.WriteLine(string.Join(",", movie.Genre));
            //    Console.WriteLine(movie.Year);
            //    Console.WriteLine();
            //}
            Console.ReadLine();
        }  
