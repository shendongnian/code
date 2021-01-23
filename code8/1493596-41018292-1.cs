    public JsonResult SavePhoto(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
            ms.Write(bytes, 0, bytes.Length);
            Image image = Image.FromStream(ms, true);
            string filestoragename = Guid.NewGuid().ToString() + ".jpeg";
            string outputPath = HttpContext.Current.Server.MapPath(@"~/Img/" + filestoragename);
            image.Save(outputPath, ImageFormat.Jpeg);
            return Json(new { status = true }, JsonRequestBehavior.DenyGet);
        }
