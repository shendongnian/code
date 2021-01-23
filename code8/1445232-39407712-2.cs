    var mail = new MailMessage();
    var imageToInline = new LinkedResource("Your image full path", MediaTypeNames.Image.Jpeg);
                imageToInline.ContentId = "MyImage";
                alternateView.LinkedResources.Add(imageToInline);
    mail.AlternateViews.Add(body);
