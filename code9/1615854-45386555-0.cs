    // Controller.cs
    public IEnumerable<CustomerTO> FetchJson(HttpPostedFile file) 
    {
    	string fileContent;
    	using (StreamReader sr = new StreamReader(file.FileName)) {
    		file.saveAs("details.txt");
    		fileContent = sr.ReadToEnd();
    	}
    
    	var customers = JsonSerializer.Deserialize<List<CustomerTO>>(content); // Refactored
    
    	return customers; 
    }
    
    // JsonSerializer.cs
    public static T Deserialize<T>(string content) {
    	// ...
    	return JsonConvert.DeserializeObject<T>(content);
    }
