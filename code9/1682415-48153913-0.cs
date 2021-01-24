    public class ImageDecorator : IPdfPCellEvent
    {
        Image image;
        public ImageDecorator(Stream inputImageStream)
        {
            image = Image.GetInstance(inputImageStream);
            image.ScaleToFit(100, 100);
        }
        public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
        {
            PdfContentByte canvas = canvases[PdfPTable.BACKGROUNDCANVAS];
            canvas.AddImage(image, image.ScaledWidth, 0, 0, image.ScaledHeight, position.Right - image.ScaledWidth, position.Bottom);
        }
    }
