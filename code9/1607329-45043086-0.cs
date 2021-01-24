    public ActionResult GetSubmitFields(string orcid, string firstName, string lastName, string badgeName)
    {
        UserCreateModel vUserTemp = new UserCreateModel() { OrcidID = orcid, FirstName = firstName, LastName = lastName, BadgeName = badgeName };
        return Json(vUserTemp, JsonRequestBehavior.AllowGet);
    }
