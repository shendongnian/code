    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string originalFile = "c:\\Users\\Admin\\Desktop\\receipt mod 3.pdf";
                string copyOfOriginal = "c:\\Users\\Admin\\Desktop\\newFile.pdf";
                using (var reader = new PdfReader(originalFile))
                {
                    using (var fileStream = new FileStream(copyOfOriginal, FileMode.Create, FileAccess.Write))
                    {
                        var document = new Document(reader.GetPageSizeWithRotation(1));
                        var writer = PdfWriter.GetInstance(document, fileStream);
                        document.Open();
                        for (var i = 1; i <= reader.NumberOfPages; i++)
                        {
                            document.NewPage();
                            var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            var importedPage = writer.GetImportedPage(reader, i);
                            var contentByte = writer.DirectContent;
                            contentByte.BeginText();
                            contentByte.SetFontAndSize(baseFont, 12);
                            var LineString = "Hello World!";
                            contentByte.ShowTextAligned(10,LineString,50,50,0);
                            contentByte.EndText();
                            contentByte.AddTemplate(importedPage, 0, 0);
                        }
                        document.Close();
                        writer.Close();
                    }
                }
            }
        }
    }
