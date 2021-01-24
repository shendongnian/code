    public void ProcessRequest (HttpContext context) {
        string imgName = context.Request.QueryString["n"];
        context.Response.ContentType = "image/png";
        string path = @"mypath" + imgName;
        Image image = Image.FromFile(path);
        image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        //I added this line
        image.Dispose();
    }
