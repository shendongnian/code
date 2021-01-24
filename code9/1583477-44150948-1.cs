     #region GetImageStream
        public static Stream GetImageStream(Stream stream)
        {
            Stream imageStream = new MemoryStream();
            if (stream != null)
            {
                using (Image targetimage = BWS.AWS.S3.ResizeImage(System.Drawing.Image.FromStream(stream), new Size(1600, 1600), true))
                {
                    targetimage.Save(imageStream, ImageFormat.Jpeg);
                }
            }
            return imageStream;
        }
        #endregion
