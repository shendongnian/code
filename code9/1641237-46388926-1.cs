    class Movie
    {
        public string DirectorNames
        {
            get
            {
                return Directors.Aggregate("", (result, director) => string.Concat(result, result.Length>0?", ":"", director.Name);
            }
        }
    }
