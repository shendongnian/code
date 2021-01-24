        public ActionResult DownloadFile()
        {
            Image imageIn = GetImage();
            imageIn.Save(Response.OutputStream, ImageFormat.Png);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
