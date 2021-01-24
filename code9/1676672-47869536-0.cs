    var doc = JsonConvert.SerializeObject(message);    
    var stringContent = new StringContent(
        	message,
        	UnicodeEncoding.UTF8,
        	"application/json");
        
    HttpClient client = new HttpClient();                
        
    client.PostAsync("apiUrl", stringContent);
