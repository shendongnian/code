    public ActionResult Index()
        {
            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "Open", Value = "1" });
            Status.Add(new SelectListItem { Text = "Closed", Value = "2" });
            Status.Add(new SelectListItem { Text = "Delete", Value = "3" });
            ViewData["Status"] = Status;
            return View();
        }
    
    @Html.DropDownList("Status", new SelectList((System.Collections.IEnumerable)ViewData["Status"], "Value", "Text"))
