    using (var client = new HttpClient())
    {
        var response = client.GetAsync(apiUri).Result;
        // For single objects.
        MyObject data = response.Content.ReadAsAsync<MyObject>().Result;
        // For an array of objects
        IEnumerable<MyObject> data = response.Content.ReadAsAsync<IEnumerable<MyObject>>().Result;
    }
