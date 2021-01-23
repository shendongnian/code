            EmailMessage msg = new CMS.EmailEngine.EmailMessage();
            EmailTemplateInfo etInfo = EmailTemplateProvider.GetEmailTemplate("Email", SiteContext.CurrentSiteID);
            if (etInfo != null)
            {
                MacroResolver mcr = MacroResolver.GetInstance();
                mcr.SetNamedSourceData("siteurl", "http://google.com/");
                mcr.SetNamedSourceData("SentBy", "admin");
    
                msg.EmailFormat = EmailFormatEnum.Both;
                msg.From = etInfo.TemplateFrom;
                msg.Recipients = "xyz@google.com";
                msg.Subject = etInfo.TemplateSubject;
                msg.Body = mcr.ResolveMacros(etInfo.TemplateText);
                msg.PlainTextBody = mcr.ResolveMacros(etInfo.TemplatePlainText);
    
                //Send Email..
                EmailSender.SendEmailWithTemplateText(SiteContext.CurrentSiteName, msg, etInfo, mcr, true);
            }
