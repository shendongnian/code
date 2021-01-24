    public static Image ThumbnailImage(Image sourceImage, int imageSize, bool maintainAspectRatio, bool maintainImageSize, Color backgroundColor)
            {
                try
                {
    
                    int thumbnailWidth = imageSize;
                    int thumbnailHeight = imageSize;
    
                    if (maintainAspectRatio)
                    {
                        float aspectRatio = (float) sourceImage.Width/sourceImage.Height;
                        float targetAspectRatio = (float) thumbnailWidth/thumbnailHeight;
    
                        if (aspectRatio < targetAspectRatio)
                        {
                            thumbnailWidth = (int) (thumbnailHeight*aspectRatio);
                        }
                        else if (aspectRatio > targetAspectRatio)
                        {
                            thumbnailHeight = (int) (thumbnailWidth/aspectRatio);
                        }
                    }
    
                    Image thumbnail = sourceImage.GetThumbnailImage(thumbnailWidth, thumbnailHeight, null, new IntPtr());
    
                    if (maintainImageSize)
                    {
                        var offset = new Point(0, 0);
                        if (thumbnailWidth != imageSize)
                        {
                            offset.X = ((imageSize - thumbnailWidth)/2);
                        }
                        if (thumbnailHeight != imageSize)
                        {
                            offset.Y = ((imageSize - thumbnailHeight)/2);
                        }
    
                        var bmpImage = new Bitmap(imageSize, imageSize, PixelFormat.Format32bppArgb);
    
                        using (Graphics graphics = Graphics.FromImage(bmpImage))
                        {
                            graphics.Clear(backgroundColor);
                            graphics.DrawImage(thumbnail, new Rectangle(offset.X, offset.Y, thumbnailWidth, thumbnailHeight), new Rectangle(0, 0, thumbnailWidth, thumbnailHeight), GraphicsUnit.Pixel);
                        }
                        thumbnail.Dispose();
                        return Image.FromHbitmap(bmpImage.GetHbitmap());
                    }
                    return thumbnail;
                }
                catch (Exception exception)
                {
                    const string strExMsg = "Error Creating Thumbnail";
                    throw new Exception(Assembly.GetExecutingAssembly().GetName().Name + " - " + strExMsg + " Msg : " + exception.Message);
                }
    
            }
