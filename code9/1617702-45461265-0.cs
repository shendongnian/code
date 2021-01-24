    public ActionResult API()
    {
        var client = new WebClient();
        var text = client.DownloadString("https://www.example.com/api/all-users?
        name=user%20&pass=password");
        wclients wclients = JsonConvert.DeserializeObject<wclients>(text);
        
        if (wclients.message == "success")
        {   
            
            ViewBag.name = wclients.data
        }
    
        return View();
    }
