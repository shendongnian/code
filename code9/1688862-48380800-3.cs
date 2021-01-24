    public class ColorizeBackgroundEvent : IPdfPCellEvent
    {
        BaseColor color;
        public ColorizeBackgroundEvent(BaseColor color)
        {
            this.color = color;
        }
        public void CellLayout(PdfPCell cell, iTextSharp.text.Rectangle position, PdfContentByte[] canvases)
        {
            PdfContentByte canvas = canvases[PdfPTable.BACKGROUNDCANVAS];
            canvas.SaveState();
            canvas.SetColorFill(color);
            canvas.Rectangle(position.Left, position.Bottom, position.Width, position.Height);
            canvas.Fill();
            canvas.RestoreState();
        }
    }
