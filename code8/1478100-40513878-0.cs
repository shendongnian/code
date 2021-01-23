    public class JsonResponse {
       [JsonProperty("results")]
       public List<Movie> Movies { get; set; }
       [JsonProperty("page")]
       public int Page { get; set; }
       [JsonProperty("total_results")]
       public int TotalResults { get; set; }
       [JsonProperty("total_pages")]
       public int TotalPages { get; set; }
    }
    
    response = JsonConvert.DeserializeObject<JsonResponse>(jsonString.Result);
    movies = response.Movies;
