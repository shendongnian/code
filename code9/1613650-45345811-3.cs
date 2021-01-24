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
            Rectangle rectToFit = new Rectangle(position);
            rectToFit.Top = rectToFit.Bottom + 10 * rectToFit.Width;
            image.ScaleToFit(rectToFit);
            image.SetAbsolutePosition(position.Left, (position.Bottom + position.Top - image.ScaledHeight) / 2);
            canvas.SaveState();
            canvas.Rectangle(position.Left, position.Bottom, position.Width, position.Height);
            canvas.Clip();
            canvas.NewPath();
            canvas.AddImage(image);
            canvas.RestoreState();
        }
    }
