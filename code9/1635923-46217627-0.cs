    [AllowAnonymous]
    public ActionResult ShowPhoto(Guid id)
    {
        using (var db = new myDB())
        {
            var p = db.mImages.Find(id);
            System.IO.MemoryStream myMemStream = new System.IO.MemoryStream(p.Photo);
            System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
            System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(150, 150, null, IntPtr.Zero);
            System.IO.MemoryStream myResult = new System.IO.MemoryStream();
            newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg);      //Or whatever format you want.
            return Json(new { myResult.ToArray() });
        }
    }
