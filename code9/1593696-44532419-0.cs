    using (var client = new HttpClient())
        try
        {
            string url = "http://conferencecreating-com.stackstaging.com/UsersWebService.php";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
    
            var stringResult = await response.Content.ReadAsStringAsync();
            var YourData = JsonConvert.DeserializeObject<User>(stringResult);
            return YourData;
        }
        catch (HttpRequestException httpRequestException)
        {
            return null;
        }
    }
