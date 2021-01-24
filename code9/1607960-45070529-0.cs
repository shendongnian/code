     public ActionResult EditProfile(Contact model, string currentPassword, string CurrentPasswordQ, string newPassword, string loginPwd, string currentPinQ, string newPin, int? selectedQuestion, string answer, bool pwdChange = false, bool questionChange = false, bool pinChange = false)
        {
    if (Request.Files != null && Request.Files.Count > 0)
    {
        HttpPostedFileBase file = Request.Files[0];
        if (file != null && file.ContentLength > 0)
        {
                 //other logic
        }
    }
