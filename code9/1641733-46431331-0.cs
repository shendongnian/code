        private System.Drawing.Image ResizeAndDraw(System.Drawing.Image objTempImage)
            {
              // call image helper to fix the orientation issue 
                var temp = ImageHelper.RotateImageByExifOrientationData(objTempImage, true);
                Size objSize = new Size(150, 200);
                Bitmap objBmp;
                objBmp = new Bitmap(objSize.Width, objSize.Height);
                Graphics g = Graphics.FromImage(objBmp);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //Rectangle rect = new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
                Rectangle rect = new Rectangle(0,0,150,200);
                //g.DrawImage(objTempImage, rect, 0, 0, objTempImage.Width, objTempImage.Height, GraphicsUnit.Pixel);
                g.DrawImage(objTempImage, rect);
                return objBmp;
            }
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    
    public static class ImageHelper
    {
        /// <summary>
        /// Rotate the given image file according to Exif Orientation data
        /// </summary>
        /// <param name="sourceFilePath">path of source file</param>
        /// <param name="targetFilePath">path of target file</param>
        /// <param name="targetFormat">target format</param>
        /// <param name="updateExifData">set it to TRUE to update image Exif data after rotation (default is TRUE)</param>
        /// <returns>The RotateFlipType value corresponding to the applied rotation. If no rotation occurred, RotateFlipType.RotateNoneFlipNone will be returned.</returns>
        public static RotateFlipType RotateImageByExifOrientationData(string sourceFilePath, string targetFilePath, ImageFormat targetFormat, bool updateExifData = true)
        {
            // Rotate the image according to EXIF data
            var bmp = new Bitmap(sourceFilePath);
            RotateFlipType fType = RotateImageByExifOrientationData(bmp, updateExifData);
            if (fType != RotateFlipType.RotateNoneFlipNone)
            {
                bmp.Save(targetFilePath, targetFormat);
            }
            return fType;
        }
    
        /// <summary>
        /// Rotate the given bitmap according to Exif Orientation data
        /// </summary>
        /// <param name="img">source image</param>
        /// <param name="updateExifData">set it to TRUE to update image Exif data after rotation (default is TRUE)</param>
        /// <returns>The RotateFlipType value corresponding to the applied rotation. If no rotation occurred, RotateFlipType.RotateNoneFlipNone will be returned.</returns>
        public static RotateFlipType RotateImageByExifOrientationData(Image img, bool updateExifData = true)
        {
            int orientationId = 0x0112;
            var fType = RotateFlipType.RotateNoneFlipNone;
            if (img.PropertyIdList.Contains(orientationId))
            {
                var pItem = img.GetPropertyItem(orientationId);
                fType = GetRotateFlipTypeByExifOrientationData(pItem.Value[0]);
                if (fType != RotateFlipType.RotateNoneFlipNone)
                {
                    img.RotateFlip(fType);
                    // Remove Exif orientation tag (if requested)
                    if (updateExifData) img.RemovePropertyItem(orientationId);
                }
            }
            return fType;
        }
    
        /// <summary>
        /// Return the proper System.Drawing.RotateFlipType according to given orientation EXIF metadata
        /// </summary>
        /// <param name="orientation">Exif "Orientation"</param>
        /// <returns>the corresponding System.Drawing.RotateFlipType enum value</returns>
        public static RotateFlipType GetRotateFlipTypeByExifOrientationData(int orientation)
        {
            switch (orientation)
            {
                case 1:
                default:
                    return RotateFlipType.RotateNoneFlipNone;
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
                case 4:
                    return RotateFlipType.Rotate180FlipX;
                case 5:
                    return RotateFlipType.Rotate90FlipX;
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                case 7:
                    return RotateFlipType.Rotate270FlipX;
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
            }
        }
    }
