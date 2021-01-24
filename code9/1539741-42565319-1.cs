    public static async Task<List<UserObject>> GetRequest()
    {
        Uri geturi = new Uri("url"); //replace your url
        System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        System.Net.Http.HttpResponseMessage responseGet = await client.GetAsync(geturi);
        string response = await responseGet.Content.ReadAsStringAsync();
        //return response;
        var json = await responseGet.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<UserObject>>(json);
        return result;
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        UsersObject myGetRequest = new UsersObject();
        myGetRequest.users = await GetRequest();
        
        //to iterate all users you got do this:
        foreach(var item in myGetRequest.users)
        {
            //do something
        }
    }
