    Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage("Your base64 image string"));
    System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
    public static string FixBase64ForImage(string Image)
    {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", string.Empty); sbText.Replace(" ", string.Empty);
            return sbText.ToString();
    }
    var mail = new MailMessage();
    var imageToInline = new LinkedResource(streamBitmap , MediaTypeNames.Image.Jpeg);
    imageToInline.ContentId = "MyImage";
    alternateView.LinkedResources.Add(imageToInline);
    mail.AlternateViews.Add(body);
