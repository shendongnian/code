    using (System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("test.png")))
    {
         var excelImage = ws.Drawings.AddPicture("My Logo", image);
         excelImage.SetPosition(1, 0, 5, 0);
    }
