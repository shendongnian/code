    public RegionViewModel()
    {
    	// Pidiendo las ciudades al backend.
    	S3EWebApi webApi = new S3EWebApi();
    	HttpResponseMessage response = webApi.Get("/api/Benefits/GetCountriesAndCities");
    	string jsonResponseString = response.Content.ReadAsStringAsync().Result;
    	CountriesAndCitiesResponse response = JsonConvert.DeserializeObject<CountriesAndCitiesResponse>(jsonResponseString);
    
    	Countries = response.CountriesAndCities;
    }
