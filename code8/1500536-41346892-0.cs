    public static void StoreImage(byte[] image, int destinationWidth, int destinationHeight, Point anchor)
        {
            using (var inStream = new MemoryStream(image))
            using (var imageFactory = new ImageFactory())
            {
                // Load the image in the image factory
                imageFactory.Load(inStream);
                var originalSourceWidth = imageFactory.Image.Width;
                var originalSourceHeight = imageFactory.Image.Height;
                // Resizes the image until the shortest side reaches the set given dimension. 
                // This will maintain the aspect ratio of the original image.
                imageFactory.Resize(new ResizeLayer(new Size(destinationWidth, destinationHeight), ResizeMode.Min));
                var resizedSourceWidth = imageFactory.Image.Width;
                var resizedSourceHeight = imageFactory.Image.Height;
                //Adjust anchor position
                var resizedAnchorX = anchor.X/(originalSourceWidth / resizedSourceWidth);
                var resizedAnchorY = anchor.Y/(originalSourceHeight/resizedSourceHeight);
                if (anchor.X > originalSourceWidth || anchor.Y > originalSourceHeight)
                {
                    throw new Exception($"Invalid anchor point. Image: {originalSourceWidth}x{originalSourceHeight}. Anchor: {anchor.X}x{anchor.Y}.");
                }
                
                var cropX = resizedAnchorX - destinationWidth/2;
                if (cropX < 0)
                    cropX = 0;
                var cropY = resizedAnchorY - destinationHeight/2;
                if (cropY < 0)
                    cropY = 0;
                if (cropY > resizedSourceHeight)
                    cropY = resizedSourceHeight;
                
                imageFactory
                    .Crop(new Rectangle(cropX, cropY, destinationWidth, destinationHeight))
                   .Save($@"{Guid.NewGuid()}.jpg");
            }
        }
