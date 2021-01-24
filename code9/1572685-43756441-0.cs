    // <root>/<controller>/ListMembers/123 (using default route)
    public ActionResult ListMembers(int clientId)
    {
        var houseRecords = db.Households.Where(x => x.ClientId == clientId).ToList();
        return View(houseRecords);
    }
