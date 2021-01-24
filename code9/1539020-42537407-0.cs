    public ActionResult Index()
    {
      //check your user type and set it to true/false
      ViewBag.UserType1 = true;
    }
    @if (Convert.ToBoolean(ViewBag.UserType1))
    {
       //Return view for user of type1 
    }
    else
    {
      //return view for user of type2
    }
