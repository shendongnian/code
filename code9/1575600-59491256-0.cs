    public string UploadToServer(byte[] image)
        {
            try
            {
                MemoryStream ms = new MemoryStream(image);
                var i = Bitmap.FromStream(ms);
                string time = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");
                string Filename = "IMG_" + time + ".png";
                string UploadPath = HttpContext.Current.Server.MapPath("~/Image");
                if (!Directory.Exists(UploadPath))
                    Directory.CreateDirectory(UploadPath);
                string NewFilePath = Path.Combine(UploadPath, Filename);
                File.WriteAllBytes(NewFilePath, image);
                return Filename;
            }
            catch (Exception)
            {
                throw;
            }
        }
