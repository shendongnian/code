    public class CutAndPasteTool
    {
        readonly Document document;
        readonly PdfWriter pdfWriter;
        readonly Dictionary<string, PdfTemplate> templates = new Dictionary<string, PdfTemplate>();
        public CutAndPasteTool(Rectangle pageSize, Stream os)
        {
            document = new Document(pageSize);
            pdfWriter = PdfWriter.GetInstance(document, os);
            document.Open();
        }
        public ICutter CreateCutter(PdfReader pdfReader, int pageNumber)
        {
            return new SimpleCutter(pdfReader, pageNumber, pdfWriter, templates);
        }
        public void Paste(string name, float x, float y)
        {
            pdfWriter.DirectContent.AddTemplate(templates[name], x, y);
        }
        public void NewPage()
        {
            document.NewPage();
        }
        public void Close()
        {
            document.Close();
        }
        class SimpleCutter : ICutter
        {
            readonly PdfImportedPage importedPage;
            readonly Dictionary<string, PdfTemplate> templates;
            internal SimpleCutter(PdfReader pdfReader, int pageNumber, PdfWriter pdfWriter, Dictionary<string, PdfTemplate> templates)
            {
                this.importedPage = pdfWriter.GetImportedPage(pdfReader, pageNumber);
                this.templates = templates;
            }
            public void Cut(string name, Rectangle rectangle)
            {
                PdfTemplate template = importedPage.CreateTemplate(rectangle.Width, rectangle.Height);
                template.AddTemplate(importedPage, importedPage.BoundingBox.Left - rectangle.Left, importedPage.BoundingBox.Bottom - rectangle.Bottom);
                templates.Add(name, template);
            }
        }
    }
    public interface ICutter
    {
        void Cut(string name, Rectangle rectangle);
    }
