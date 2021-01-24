     #region GetImageStream
        public static Stream GetImageStream(string Image64string)
        {
            Stream imageStream = new MemoryStream();
            if (!string.IsNullOrEmpty(Image64string))
            {
                byte[] imageBytes = Convert.FromBase64String(Image64string.Substring(Image64string.IndexOf(',') + 1));
                using (Image targetimage = BWS.AWS.S3.ResizeImage(System.Drawing.Image.FromStream(new MemoryStream(imageBytes, false)), new Size(1600, 1600), true))
                {
                    targetimage.Save(imageStream, ImageFormat.Jpeg);
                }
            }
            return imageStream;
        }
        #endregion
