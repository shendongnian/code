    HttpPostedFile hpf = context.Request.Files[0] as HttpPostedFile;
        if (hpf.ContentLength != 0)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            
            
            
            savedFileName = context.Server.MapPath("~/Uploads/" + Path.GetFileName(hpf.FileName));
            hpf.SaveAs(savedFileName);
            string File1 = Path.GetFileName(hpf.FileName);
            imageNewval = result + "_ReemEyalLia_" + DateTime.Now.ToString("ddMMyyyhhmmss");
            
            Bitmap originalBMP = new Bitmap(hpf.InputStream);
            decimal origWidth = originalBMP.Width;
            decimal origHeight = originalBMP.Height;
            decimal sngRatio = origHeight / origWidth;
            int newHeight = 200;
            decimal newWidth_temp = newHeight / sngRatio;
            int newWidth = Convert.ToInt16(newWidth_temp);
            Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
            Graphics oGraphics = Graphics.FromImage(newBMP);
            oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
            newBMP.Save(context.Server.MapPath("~/Uploads/" + imageNewval + Path.GetExtension(File1)));
            originalBMP.Dispose();
            newBMP.Dispose();
            oGraphics.Dispose();
           
        }
