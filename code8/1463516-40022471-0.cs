    public ActionResult GetImage()
    {
       var imageFile = System.Web.HttpContext.Current.Server.MapPath("ImagePathHere");
       var srcImage = Image.FromFile(imageFile);
       using (var stream = new MemoryStream())
       {
          srcImage.Save(stream, ImageFormat.Png);
          return File(stream.ToArray(), "image/png");
       }
    }
