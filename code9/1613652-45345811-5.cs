    class ImageEvent : IPdfPCellEvent
    {
        Image image;
        public ImageEvent(Image image)
        {
            this.image = image;
        }
        public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
        {
            PdfContentByte canvas = canvases[0];
            float scaleX = position.Width / image.Width;
            float scaleY = position.Height / image.Height;
            float scale = Math.Max(scaleX, scaleY);
            image.ScaleToFit(image.Width * scale, image.Height * scale);
            image.SetAbsolutePosition((position.Left + position.Right - image.ScaledWidth) / 2, (position.Bottom + position.Top - image.ScaledHeight) / 2);
            canvas.SaveState();
            canvas.Rectangle(position.Left, position.Bottom, position.Width, position.Height);
            canvas.Clip();
            canvas.NewPath();
            canvas.AddImage(image);
            canvas.RestoreState();
        }
    }
