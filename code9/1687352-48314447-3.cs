    public IActionResult Login()
    {
        string message = null;
        var item = TempData.FirstOrDefault(x =>x.Key == key);
    
        if (item.Value != null)
        {
            message = (string)item.Value;
        }
    
         return View();
    }
