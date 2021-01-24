    public ActionResult Search()
    {
        using(var context = new DBFeedbackContext())
        {
            ViewBag.CMC = context.Categories.Select(x => new SelectListItem() { Text = x, Value = x.Id.ToString() }).ToList();
            return View();
        }
    }
