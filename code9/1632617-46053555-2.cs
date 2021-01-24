    public ActionResult Dashboard_Portal()
    {
      var webClient = new WebClient();
      var json = webClient.DownloadString(@"http://elliottjbrown.co.uk/portal/js/data.json");
      var webinars = JsonConvert.DeserializeObject<Rootobject>(json);
    
      return View(webinars);
    }
