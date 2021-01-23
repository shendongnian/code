    public static string UploadImage(string imageData, string userEmail, int quantity)
    {
        imageData = HttpUtility.UrlDecode(imageData);
    
        var completePath = @"~\user-images\file.svg";
        completePath = HttpContext.Current.Server.MapPath(completePath);
        File.WriteAllText(completePath, imageData);  // <--
    }
