    // Use this for initialization
    void Start()
    {
        string json = "{\"Name\":\"Bad Boys\",\"Description\":\"\",\"Classification\":\"\",\"Studio\":\"Pixa\",\"ReleaseCountries\":[\"Japan\"]}";
    
        Movie movie = Load<Movie>(json);
        print(movie.Name);
    }
    
    [Serializable]
    public class Movie
    {
        public string Name;
        public string Description;
        public string Classification;
        public string Studio;
        public DateTime? ReleaseDate;
        public List<string> ReleaseCountries;
    }
    
    private T Load<T>(string json)
    {
        object resultValue = JsonUtility.FromJson<T>(json);
        return (T)Convert.ChangeType(resultValue, typeof(T));
    }
