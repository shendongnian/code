    public ActionResult GetSubmitFields(string orcid, string firstName, string lastName, string badgeName) {
        return Json(
            new UserCreateModel {
                OrcidID = orcid
            ,   FirstName = firstName
            ,   LastName = lastName
            ,   BadgeName = badgeName
            }
        ,   JsonRequestBehavior.AllowGet
        );
    }
