    public IActionResult About()
    {
       if (TempData["rvm"] is string s)
       {
           var rvm = JsonConvert.DeserializeObject<RegisterViewModel>(s);
           // use rvm now
       }
       // to do : return something
    }
