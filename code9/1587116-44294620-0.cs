    public PartialViewResult UnReadEmails()
    {
       if (User.Id != null)
       {
          List<Emails> resultList = EmailController.GetUnreadEmailsByUserId(User.Id);
           return PartialView("_UnReadEmails", resultList);
       }
       return PartialView("_UnReadEmails" new List<Emails>());
    }
