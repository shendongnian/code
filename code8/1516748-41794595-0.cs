    void createValidMovieJson()
    {
        Movie m = new Movie();
        m.Name = "Bad Boys";
        m.ReleaseCountries = new List<string>();
        m.ReleaseCountries.Add("Japan");
    
        m.Studio = "Pixa";
        Debug.Log(JsonUtility.ToJson(m));
    }
