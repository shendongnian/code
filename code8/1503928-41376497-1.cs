    protected class MyEvent : PdfPageEventHelper {
     
        Image image;
     
        public override void OnOpenDocument(PdfWriter writer, Document document) {
            image = Image.GetInstance(Server.MapPath("~/images/background.png"));
            image.SetAbsolutePosition(0, 0);
        }
     
        public override void OnEndPage(PdfWriter writer, Document document) {
            writer.DirectContent.AddImage(image);
        }
    }
