    [HttpPost]
    public ActionResult Submit(URLModel model)
    {
        string url = EmailEnd(model);
        if (url != "0")
        {
            return RedirectToAction("RedirectingTime", new { url = url });
        }
        else
        {
            return RedirectToAction("Error");
        }
    }
    
    public RedirectResult RedirectingTime(string url)
    {
        return Redirect(url);
    }
    public ActionResult Error()
    {
        return View();
    }
