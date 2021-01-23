        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    using System.Drawing;
    
    namespace testtables1
    {
        class Program
        {
            static void Main(string[] args)
            {
                iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(300, 720);
                Document pdfToCreate = new Document(pageSize, 0, 0, 0, 0);
                PdfWriter writer = PdfWriter.GetInstance(pdfToCreate, new FileStream(@"D:\\testfile.pdf", FileMode.Create));
                pdfToCreate.Open();
    
                PdfPTable table = new PdfPTable(1);
                PdfPTable tableout = new PdfPTable(1);
    
                WriteLineToPdf("This is first row. Below is image generated using SystemDrawing.", table, out tableout);
                table = tableout;
    
                // Create bar code
                Barcode128 code128 = new Barcode128();
                code128.CodeType = Barcode.CODE128;
                code128.ChecksumText = true;
                code128.GenerateChecksum = true;
                code128.Code = "00100370006756555316";
    
                // Create a new PdfWrite object, writing the output to a MemoryStream
                var outputStream = new MemoryStream();
                var pdfWriter = PdfWriter.GetInstance(pdfToCreate, outputStream);
                PdfContentByte cb = new PdfContentByte(writer);
                
                // Image generated using System.Drawing and rendering
                System.Drawing.Bitmap bm = new System.Drawing.Bitmap(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
                iTextSharp.text.Image bmCoverted = iTextSharp.text.Image.GetInstance(bm, System.Drawing.Imaging.ImageFormat.Bmp);
                table.AddCell(bmCoverted);
    
                pdfToCreate.Open();
    
                // Image generated using iTextSharp.text.Image
                WriteLineToPdf("This is third row. Below is image generated using code128.CreateImageWithBarcode.", table, out tableout);
                table = tableout;
                iTextSharp.text.Image image128 = code128.CreateImageWithBarcode(cb, null, null);
                table.AddCell(image128);
                table = tableout;
    
                WriteLineToPdf("This is fifth row.", table, out tableout);
                pdfToCreate.Add(tableout);
    
                // Create new document with height that depends on number of lines in document.
                iTextSharp.text.Rectangle psFinal = new iTextSharp.text.Rectangle(200, 300);
                Document pdfFinal = new Document(psFinal, 0, 0, 0, 0);
                PdfWriter writer1 = PdfWriter.GetInstance(pdfFinal, new FileStream(@"D:\\finalfile.pdf", FileMode.Create));
                pdfFinal.Open();
                pdfFinal.Add(tableout);
    
                cb = null;
    
                pdfToCreate.Close();
                pdfFinal.Close();
            }
    
            // Write a single line to the PDF.
            private static void WriteLineToPdf(string tLine, PdfPTable ticTable0In, out PdfPTable ticTableIN)
            {
                // Define fonts.
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);   // Base font.
                iTextSharp.text.Font timesN = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK); 
    
                Paragraph par = new Paragraph(tLine, timesN);
                par.Alignment = Element.ALIGN_CENTER;
                PdfPCell cell;
    
                cell = new PdfPCell();
                //cell.FixedHeight = 12f;
                //cell.Border = Rectangle.NO_BORDER;
    
    
                cell.AddElement(par);
                ticTable0In.AddCell(cell);
                ticTableIN = ticTable0In;
                par = null;
    
            }
        }
    }
