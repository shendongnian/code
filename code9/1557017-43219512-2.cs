    public class LowerRightImage : IPdfPCellEvent
    {
        public Image Image { get; set;  }
    
        public void CellLayout(
            PdfPCell cell, 
            Rectangle position, 
            PdfContentByte[] canvases)
        {
            if (Image == null) throw new InvalidOperationException("image is null");
    
            PdfContentByte canvas = canvases[PdfPTable.TEXTCANVAS];
            Image.SetAbsolutePosition(
                position.Right - Image.ScaledWidth - cell.PaddingRight, 
                position.Bottom + cell.PaddingBottom
            );
            canvas.AddImage(Image);
        }
    }
