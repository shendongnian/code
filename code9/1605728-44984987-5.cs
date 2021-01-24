    public ActionResult GetClients()
    {
        var clients = RetrieveClients("R");
        return View(clients);
    }
