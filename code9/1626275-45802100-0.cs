    [HttpPost]
    public RedirectResult VaiAllaHome(bool? nascondi = false, IEnumerable<Messaggio> elencoPost = null)
    {
        // do something
        return RedirectToAction("Action", "Controller", new { routeParameter = value } /*e.g. "id = 1"*/);
    }
