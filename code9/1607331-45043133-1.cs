    public ActionResult GetSubmitFields(dynamic user) {
        return Json(
            new UserCreateModel {
                OrcidID = user.OrcId
            ,   FirstName = user.FirstName
            ,   LastName = user.lastName
            ,   BadgeName = user.badgeName
            }
        ,   JsonRequestBehavior.AllowGet
        );
    }
