    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Authorization =
            AuthenticationHeaderValue.Parse("Bearer " + accessToken);
    
        using (HttpResponseMessage response = await client.GetAsync("https://www.googleapis.com/plus/v1/people/me"))
        {
            var googlePlusUserInfo = 
                JsonConvert.DeserializeObject<GooglePlusUserInfo>(await response.Content.ReadAsStringAsync());
    
            googlePlusUserInfo.Email = googlePlusUserInfo.Emails.Count() > 0 ? 
                                        
            googlePlusUserInfo.Emails.First().EmailAddress : "";
                                    
            googlePlusUserInfo.ProfilePicure.ImageUrl = 
            googlePlusUserInfo.ProfilePicure.ImageUrl.Split(new char[] { '?' })[0];
    
            return googlePlusUserInfo;
        }
    }
