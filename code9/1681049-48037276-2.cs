    View:
       
    
     @Html.DropDownList("MJTopicsID", 
        (List<SelectListItem>)@ViewBag.MJTopics, 
          htmlAttributes: new { @class = "form-control" }) 
    Action:
       
    
     public ActionResult Index()
        {
            ViewBag.MJTopics = new List<SelectListItem>() {
                new SelectListItem(){Text = "Topic1", Value ="1" },
                new SelectListItem(){Text = "Topic2", Value ="2" }
            };
            return View();
        }
