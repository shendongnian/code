        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace TableWithBC2
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (MemoryStream myMemoryStream = new MemoryStream())
                {
                    PdfPTable tableIn;
                    Document pdfDocument = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(pdfDocument, myMemoryStream);
                    PdfPTable tableOut = new PdfPTable(new float[] { 200 });
                    tableIn = new PdfPTable(new float[] { 200 });
                    pdfDocument.Open();
    
                    for (int i = 0; i < 5; i++)
                    {
    					WriteLineToPdf("This is row no. " + i.ToString(), tableIn, out tableOut);
                        tableIn = tableOut;
                    }
    
                    // Create bar code
                    PdfContentByte cb = writer.DirectContent;
                    Barcode128 code128 = new Barcode128();
                    code128.CodeType = Barcode.CODE128;
                    code128.ChecksumText = true;
                    code128.GenerateChecksum = true;
                    code128.Code = "00100370006756555316";
                    Image barCodeImage = code128.CreateImageWithBarcode(cb, null, null);
                    PdfPCell cell1 = new PdfPCell(barCodeImage);
                    tableOut.AddCell(cell1);
                    tableIn = tableOut;
                    WriteLineToPdf("This is a last row.", tableIn, out tableOut);
    
                    pdfDocument.Add(tableOut);
                    pdfDocument.Close();
    
                    // Create final PDF document.
                    Document pdfDocument1 = new Document(new Rectangle(200, 250));
                    PdfWriter writer1 = PdfWriter.GetInstance(pdfDocument1, new FileStream(@"D:\\result.pdf", FileMode.Create));
                    pdfDocument1.Open();
                    pdfDocument1.Add(new Chunk());
                    pdfDocument1.Close();
    
                    byte[] content = myMemoryStream.ToArray();
    
                    // Write out PDF from memory stream. 
                    using (FileStream fs = File.OpenWrite(@"D:\\nikola bd - final\\out\\dummy22.pdf"))
                    {
                        fs.Write(content, 0, (int)content.Length);
                    }
                }
            }
            // Write a single line to the PDF.
            private static void WriteLineToPdf(string tLine, PdfPTable tTableIn, out PdfPTable tTableOut)
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                iTextSharp.text.Font timesN = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.NORMAL, BaseColor.RED);
    
                Paragraph par = new Paragraph(tLine, timesN);
                par.Alignment = Element.ALIGN_CENTER;
                PdfPCell cell = new PdfPCell();
                cell.AddElement(par);
                tTableIn.AddCell(cell);
                tTableOut = tTableIn;
            }
        }
    }
