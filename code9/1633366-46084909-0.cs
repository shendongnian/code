    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    
    namespace TestError
    {
        public class TestCode
        {
            public void DupePages(string inFilePath, string outFilePath)
            {
                var inDoc = PdfReader.Open(inFilePath, PdfDocumentOpenMode.Import);
                var outDoc = new PdfDocument();
    
                var page = inDoc.Pages[0];
                outDoc.AddPage(page);
                page.Rotate = 0;
                outDoc.AddPage(page);
    
                outDoc.Save(outFilePath);
            }
        }
    }
