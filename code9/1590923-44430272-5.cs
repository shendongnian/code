    public ActionResult ActionName()
    {
     List<SelectListItem> Items = new List<SelectListItem>();
            CustReportName.Add(new SelectListItem() { Text = "List1", Value = "1", Selected = false });
            CustReportName.Add(new SelectListItem() { Text = "List2", Value = "2", Selected = true });
            ViewBag.ListItems = Items;
    return View("ViewName");
    }
