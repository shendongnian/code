    public static async Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        var movies = new List<Movie>();
        var url = "http://jsonmock.hackerrank.com/api/movies/search/?Title=spiderman";
        int currentPage = 1;
        int totalPages = 0;
        var nextUrl = $"{url}&page={currentPage}";
        using (var httpClient = new HttpClient())
        { 
            do
            {
                HttpResponseMessage response = await httpClient.GetAsync(nextUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var pageResponse = JsonConvert.DeserializeObject<PageResponse>(json);
                    if (pageResponse != null && pageResponse.Data.Any())
                    {
                        movies.AddRange(pageResponse.Data);
                        totalPages = pageResponse.TotalPages;
                        currentPage++;
                        nextUrl = $"{url}&page={currentPage}";
                    }
                    else
                    {
                        break; // or throw exception
                    }
                }
                else
                {
                    break; // or throw exception
                }
            } while (currentPage < totalPages);
        }
        return movies;
    }
