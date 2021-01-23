    public static ObservableCollection<SearchItems> GetTVShows(int start, int finish)
    {
        var movies = new ObservableCollection<SearchItems>();
        for (int x = start; x < finish; x++)
        {
            movies.Add(new SearchItems { SearchID = (x + 1), SearchTitle = SearchPage.SearchTitles[x], SearchImageLink = SearchPage.SearchImageLinks[x], SearchLink = SearchPage.SearchLinks[x] });
        }
        if (start == 0 && finish == 0)
        {
            movies.Add(new SearchItems { SearchID = 1, SearchTitle = "No Search Results", SearchImageLink = @"ms-appx:///Assets/noposter.jpg" });
        }
        return movies;
    }
