     var client = new HttpClient();
     var stringContent = new StringContent(JsonConvert.SerializeObject(objuser), Encoding.UTF8, "application/x-www-form-urlencoded");
    
     stringContent.Headers.Add("j_username", objuser.j_username);
     stringContent.Headers.Add("j_password", objuser.j_password); 
     HttpResponseMessage response = client.PostAsync(@"URL"?j_username=" + objuser.j_username + "&j_password=" + HttpUtility.UrlEncode(objuser.j_password), stringContent).Result;
     string path2 = "URL/getall";
                   
     var response1 = await client.GetAsync(path2);
    
      var data = await response1.Content.ReadAsStringAsync();
         if (true)
            {
         var data2 = JsonConvert.DeserializeObject<RootObject>(data);
             }
