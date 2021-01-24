    public IActionResult About()
    {
       if (TempData["MyModelDict"] is Dictionary<string,string> dict)
       {
          var name = dict["Name"];
          var email =  dict["Email"];
       }
       // to do : return something
    }
 
