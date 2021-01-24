    static void Main(string[] args)
        {                   
            var jo = JObject.Parse(File.ReadAllText("data.json").Trim('{').Trim('}'));
            foreach (var place in jo)
            {
                Console.WriteLine($"Place: {place.Key}");
                foreach (var dateOrMovie in place.Value.Children<JProperty>())
                {
                    Console.WriteLine($"\tDate: {dateOrMovie.Name}");
                    var movies = dateOrMovie.Children<JObject>().First().Children<JProperty>();
                    foreach (var movie in movies)
                    {
                        Console.WriteLine($"\t\t{movie.Name}");
                        foreach (JValue time in movie.Children<JArray>().First())
                        {
                            Console.WriteLine($"\t\t\t{time.Value}");
                        }
                    }
                }
            }
        }
