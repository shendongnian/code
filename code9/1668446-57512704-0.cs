    public async Task<ReturnViewModel> ModContactsAsync(List<ContactsDTO> Contacts)
    {
    	ReturnViewModel vm = new ReturnViewModel();
    
    	var bodyContent = JsonConvert.SerializeObject(Contacts);
    		
    	using (var client = new HttpClient())
    	{
    		var response = await client.PostAsync(AppConfig.ServiceUrlBase, new StringContent(bodyContent, Encoding.UTF8, "application/json"));
    
    		return responseString.Result.Content.ReadAsStringAsync().Result;
    	}
    		
    	return vm;
    }
