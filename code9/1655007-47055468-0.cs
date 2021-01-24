    public ActionResult MakeOrder()
    {
        var data = (ProcessOrderViewModel)System.Web.HttpContext.Current.Session["Process"]; 
        bool individualDataValid = TryValidateModel(data.PrivateIndividualData);
        bool discountDataValid = TryValidateModel(data.OrderDiscoutPrice);
        if (individualDataValid && discountDataValid)
        {
            // make order with this data
            return View("Thank You");
        }
        
        //Error condition
        return View("Error");
    }
