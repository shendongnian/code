    public ActionResult ActionName()
    {
    IEnumerable<SelectListItem> ItemsList = from item in YourTableObject
    select new SelectListItem
    {
    Value = Convert.ToString(item.Id),
    Text = item.ItemName
    };
    ViewBag.ListItems = new SelectList(ItemsList, "Value", "Text");
    return View("ViewName");
    }
