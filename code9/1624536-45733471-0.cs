    // Make your request
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestURL);
    request.Headers.Add("Accept", "application/xml");
    HttpResponseMessage response = client.SendAsync(request).Result;
    
    // Parse your response
    if (response.IsSuccessStatusCode)
    {
    	using (Stream httpResponseStream = response.Content.ReadAsStreamAsync().Result)
    	{
    		XDocument responseXML = XDocument.Load(httpResponseStream);
    		
    		// My Chosen element is the element you're looking for
    		IEnumerable<XElement> myElements = responseXML.Root.Elements("MyChosenElement");
    		
    		foreach (XElement myEl in myElements)
    		{
    			// Access each element like this myEl.Child
    			// Do what you'd like with it
    		}
    	}
    }
