    string filename = i.PicturePath;
    if (string.IsNullOrEmpty(filename))
    {
        filename = "default-artwork.png";
    }
    string fullPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/" + filename);
    byte[] bytes = System.IO.File.ReadAllBytes(fullPath);
