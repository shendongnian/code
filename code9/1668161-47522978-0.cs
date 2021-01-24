    var item = "3000/1/1/3.png";
    var imageBaseLocation = "~/Images";
    var fullPath = Path.Combine(imageBaseLocation, item);
    var physicalLocation = System.Web.HttpContext.Current.Server.MapPath(fullPath);
    message.Attachments.Add(new Attachment(physicalLocation));
