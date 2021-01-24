    var client = new HttpClient();
    
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    
    	var model = new Rootobject { State = "Andhra_Pradesh", District = "Guntur", FactType = "SELECT", Description = "", CaseDate = "", FactNumber = "", Fact = new Fact { Id = "1"} };
    
    	var data = await client.PostAsJsonAsync("http://api.in/" + "test", model);
