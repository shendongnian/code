    var movieList = new List<MovieModel>
    { 
        new MovieModel
        {
            MovieName = "Deadpool",
            Time = DateTime.UtcNow.ToString("t"),
            Url = new Dictionary<string, string>
            {
                { "small", "http://api.android.info/images/small/deadpool.jpg" },
                { "medium", "http://api.android.info/images/medium/deadpool.jpg" }
            }
        }
        // .. add more movies .. //
    };
    // convert to camelcase and set indentation
    var output = JsonConvert.SerializeObject(
        movieList,
        Formatting.Indented,
        new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        }
    );
    // testing output on console
    Console.WriteLine(output);
