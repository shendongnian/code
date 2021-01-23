        //Controller Action 
        public ActionResult Index()
                {
                      ViewBag.HTMLContent = "Your HTML Data";
                      return View();
                }
        //View page code 
    <div id="dvLogList"> 
      @Html.Raw((String)ViewBag.HTMLContent)
    </div>
