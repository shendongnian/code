    public async Task<List<Steam>> Get()
    {
        ObjectResult result = new Models.ObjectResult();
        using (HttpClient client = new HttpClient())
        {
            var Object = await client.GetAsync("http://api.steampowered.com/ISteamApps/GetAppList/v0001/");
            if (Object != null)
            {
                JObject steamobject = JObject.Parse(Object.ToString());
                var item = steamobject.SelectToken("applist").SelectToken("apps");
                result = JsonConvert.DeserializeObject<ObjectResult>(item.ToString());
            }
    
        }
        SteamGet getter = new SteamGet();
        ViewBag.Games = await getter.Get();
        return result.MyList;
      }
