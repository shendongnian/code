    public class ImageEntitlingRenderListener : IRenderListener
    {
        BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
        PdfStamper pdfStamper = null;
        int page = 0;
        public ImageEntitlingRenderListener(PdfStamper pdfStamper, int page)
        {
            this.pdfStamper = pdfStamper;
            this.page = page;
        }
        public void RenderImage(ImageRenderInfo renderInfo)
        {
            Matrix ctm = renderInfo.GetImageCTM();
            float xCenter = ctm[Matrix.I31] + 0.5F * ctm[Matrix.I11];
            float yTop = ctm[Matrix.I32] + ctm[Matrix.I22];
            PdfContentByte pdfContentByte = pdfStamper.GetOverContent(page);
            pdfContentByte.SetColorFill(BaseColor.BLUE);
            pdfContentByte.SetFontAndSize(baseFont, 8);
            pdfContentByte.BeginText();
            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "rahul", xCenter, yTop, 0);
            pdfContentByte.EndText();
        }
        public void BeginTextBlock() { }
        public void EndTextBlock() { }
        public void RenderText(TextRenderInfo renderInfo) { }
    }
