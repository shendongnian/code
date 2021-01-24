    [HttpPost]
    public RedirectResult VaiAllaHome(bool? nascondi = false, IEnumerable<Messaggio> elencoPost = null)
    {
        // do something
        return View(Url.Content("~/"));
        //return RedirectToAction("Action", "Controller", new { routeParameter = value } /*e.g. "id = 1"*/);
    }
