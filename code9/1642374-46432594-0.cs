       using System.IO;
       using iTextSharp.text.pdf;
       using iTextSharp.text;
     static void Main(string[] args) {
            // open the writer
            string fileName = "MyPdffile.pdf";
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            Document doc = new Document();
            //Create a New instance of PDFWriter Class for Output File
            PdfWriter.GetInstance(doc, fs);
            //Open the Document
            doc.Open();
            //Add the content of Text File to PDF File
            doc.Add(new Paragraph("Document Content"));
            //Close the Document
            doc.Close();
            System.Diagnostics.Process.Start(fileName);
        }
