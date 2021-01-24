    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SubmitInput()
    {
        string  fromEmail = Request.Form["Email"],
                fromName =  Request.Form["Name"],
                toEmail =   "user@domain.com",
                subject =   "ASP.NET Core with MailKit",
                content =   Request.Form["Message"],
                site =      Request.Form["Website"],
                company =   Request.Form["CompanyName"];
        // MailKit
        Models.Mail.Send(fromEmail, fromName, toEmail, subject, content);
        return View();
    }
