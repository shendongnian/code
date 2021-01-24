        List<User> Users;
        using (var client = new HttpClient())
           try
           {
               string url = "http://conferencecreating-com.stackstaging.com/UsersWebService.php";
               var response = await client.GetAsync(url);
               response.EnsureSuccessStatusCode();
            
               var stringResult = await response.Content.ReadAsStringAsync();
               Users = JsonConvert.DeserializeObject<List<User>>(stringResult);
           }
           catch (HttpRequestException httpRequestException)
           {
               Users = null;
           }
       }
