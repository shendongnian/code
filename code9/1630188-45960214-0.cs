    using iText.Kernel.Pdf;
    using iText.Kernel.Pdf.Navigation;
    using System;
    
    
    namespace PDFConvert
    {
        class Program
        {
            static void Main(string[] args)
            {
                String InputPdf = @"test.pdf";
                String OutputPdf = "out.pdf";
    
                PdfDocument pdfDoc = new PdfDocument(new PdfReader(InputPdf), new PdfWriter(OutputPdf));
    
                PdfOutline outlines = pdfDoc.GetOutlines(false);     
                // first level     
                foreach (var outline in outlines.GetAllChildren())
                {
                    // second level
                    foreach (var second in outline.GetAllChildren())
                    {
                        String title = second.GetTitle();
                        PdfDestination dest = second.GetDestination();
    
                        pdfDoc.AddNamedDestination(title, dest.GetPdfObject());
                    }
                }
                pdfDoc.Close();
            }
        }
    }
