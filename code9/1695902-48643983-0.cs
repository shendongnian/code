    public async Task<List<Idea>> GetIdeaAsync(string accesToken)
    {
      List<Idea> ideas = null;
      try
      {
         var client = new HttpClient();
         client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesToken);
         var json = await client.GetStringAsync("http://www.getdata.de/api/ideas/");
         var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);
      }
      catch (Exception ex)
      {
        await Application.Current.MainPage.DisplayAlert("Server Error", "There has been an server error. Please try later.", "OK");
              if (ideas == null)
              {
                  //actually I would like to stay in the same page
                  return null; //-- added this line 
              }
      }
       return ideas;
    }
