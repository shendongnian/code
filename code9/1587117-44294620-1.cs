    public ActionResult UnReadEmails()
    {
       if (User.Id != null)
       {
          List<Emails> resultList = EmailController.GetUnreadEmailsByUserId(User.Id);
           return PartialView("_UnReadEmails", resultList);
       }
       return Content("Error, not found!");
    }
