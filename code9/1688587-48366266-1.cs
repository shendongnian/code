    RootObject movie = new JavaScriptSerializer().Deserialize<RootObject>(getJson());
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
        var propertyInfo = movie.GetType().GetProperty(array[i]);
        Console.WriteLine(propertyInfo.GetValue(movie).ToString());
        Console.WriteLine();
    }
    var key = Console.ReadKey();
