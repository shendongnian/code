        private StreamContent ReadImageAsStream(string imagePath)
        {
            // Code here to get image based on above parameter
            //TODO remove url
            if (string.IsNullOrEmpty(imagePath))
            {
                return Image.FromFile(@"\\Content\Images\no_image_available.png").ToStream(ImageFormat.Jpeg);
            }
            // Read and return image as stream
            return Image.FromFile(imagePath).ToStream(ImageFormat.Jpeg);
        }
