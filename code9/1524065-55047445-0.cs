     var searchParameter = new SearchTweetsParameters("#Benz")
                {
                    //GeoCode = new GeoCode(-122.398720, 37.781157, 1, DistanceMeasure.Miles),
                    Lang = LanguageFilter.English,
                    //SearchType = SearchResultType.Popular,
                    //MaximumNumberOfResults = 100,
                    Until = new DateTime(2018, 03, 07),
                    //SinceId = 399616835892781056,
                    //MaxId = 405001488843284480,
                    Filters = TweetSearchFilters.Images
                };
    
                 var tweets = Search.SearchTweets(searchParameter);
