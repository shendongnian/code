    public ActionResult GetData()
    {
        if (HttpContext.Current.Session["peopleList"] != null)
        {
            return View((List<People>)HttpContext.Current.Session["peopleList"]);
        }
        else
        {
            var result = context.People.ToList();
            HttpContext.Current.Session["peopleList"] = result;
            return View(result);
        }
    }
