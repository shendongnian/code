        /// <summary>
        /// function to reduce image size and returns local path of image
        /// </summary>
        /// <param name="scaleFactor"></param>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <returns></returns>
        private string ReduceImageSize(double scaleFactor, Stream sourcePath, string targetPath)
        {
            try
            {
                using (var image = System.Drawing.Image.FromStream(sourcePath))
                {
                    //var newWidth = (int)(image.Width * scaleFactor);
                    //var newHeight = (int)(image.Height * scaleFactor);
                    var newWidth = (int)1280;
                    var newHeight = (int)960;
                    var thumbnailImg = new System.Drawing.Bitmap(newWidth, newHeight);
                    var thumbGraph = System.Drawing.Graphics.FromImage(thumbnailImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imageRectangle);
                    thumbnailImg.Save(targetPath, image.RawFormat);
                    return targetPath;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in ReduceImageSize" + e);
                return "";
            }
        }
