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
    
    
    void Start()
    {
        Test1<Movie>();
    }
    
    private void Test1<T>()
    {
        string json = "{\"Name\":\"Bad Boys\",\"Description\":\"\",\"Classification\":\"\",\"Studio\":\"Pixa\",\"ReleaseCountries\":[\"Japan\"]}";
    
        T m = JsonUtility.FromJson<T>(json);
        print(m);
    
        Movie movie = (Movie)(object)m;
        print(movie.Name);
    }
