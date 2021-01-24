    [HttpPost]
    public void StoreMakeAndModel(string user_selections)
    {
       ViewData["message"] = user_selections;
    }
    [HttpGet]
    public string ConfirmationMessage()
    {
        ViewData["message"] = "You selected the " + ViewData["message"].ToString();
        return ViewData["message"].ToString();
    }
