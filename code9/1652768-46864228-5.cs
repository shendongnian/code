    [HttpPost]
    public void SaveImage2(string base64image)
    {
        if (string.IsNullOrEmpty(base64image))
            return;
           
        var t = base64image.Substring(22);  // remove data:image/png;base64,
        byte[] bytes = Convert.FromBase64String(t);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
        }
        var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";
        var fullPath = Path.Combine(Server.MapPath("~/Content/Images/"), randomFileName);
        image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
    }
