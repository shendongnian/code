    public ActionResult A(int id)
    {
        var uniqueID = CalculateUniqueFromId(id);
        return B(uniqueID);
    }
    public ActionResult B(Guid uniqueID)
    {
        var model = DoCreateModelForUnique(uniqueID);
        return View("B", model);
    }
?
