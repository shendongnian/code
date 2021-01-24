    public ActionResult searchItemReview(string searchItem, int userId)
    {
        .
        .
        .
        var str = Json.Encode(revList);
        return RedirectToAction("searchReview", "home", str);
    }
