    //... Use HttpClient.
    using (HttpClient client = new HttpClient())
    {
      using (HttpResponseMessage response = await client.GetAsync(destUri))
      {
        // Get Certificate Here
        var cert = ServicePointManager.FindServicePoint(destUri).Certificate;
        //
        using (HttpContent content = response.Content)
        {
          string result = await content.ReadAsStringAsync();
        }
      }
    }
