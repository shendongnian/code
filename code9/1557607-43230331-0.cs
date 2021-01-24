    HostingEnvironment.QueueBackgroundWorkItem(ct =>
    {
        var cm = new MailFunction();
        foreach (var clist in NewslettersList)
        {
            cm.To = clist.NewsletterEmail;
            try
            {
                cm.SendEmail(cm);
            }
            catch (Exception)
            {
            }
        }
    });
