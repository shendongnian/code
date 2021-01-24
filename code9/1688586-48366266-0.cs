    JObject movie = JObject.Parse(getJson());
    string[] array = {
                            "Title",
                            "Year",
                            "Rated",
                            "Genre",
                            "Writer",
                            "Plot"
                        };
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(movie[array[i]].ToString());
    }
    var key = Console.ReadKey();
