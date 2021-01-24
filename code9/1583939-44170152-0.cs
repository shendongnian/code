        private static void AddImageToEmail(MailMessage mail, Image image)
        {
            var imageStream = GetImageStream(image);
            var imageResource = new LinkedResource(imageStream, "image/png") { ContentId = "added-image-id" };
            var alternateView = AlternateView.CreateAlternateViewFromString(mail.Body, mail.BodyEncoding, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(imageResource);
            mail.AlternateViews.Add(alternateView);
        }
        private static Stream GetImageStream(Image image)
        {
            // Conver the image to a memory stream and return.
            var imageConverter = new ImageConverter();
            var imgaBytes = (byte[])imageConverter.ConvertTo(image, typeof(byte[]));
            var memoryStream = new MemoryStream(imgaBytes);
            return memoryStream;
        }
