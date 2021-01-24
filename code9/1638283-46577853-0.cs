    using System;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser; 
    
        private void ButtonEditPDF_Click(object sender, EventArgs e)
                {
                string fileInputPath = "input.pdf";            
                            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(40, 60);//use any image if you want
                            if (checkEditIsNewPage.Checked == true)
                            {
                                AddCommentsToFile_NewPage(fileInputPath , memoEdit1.Text,bitmap);//memoEdit1.Text or your string paragraph
                            }
                            else
                            {
                                AddCommentsToFile_SamePage(fileInputPath , memoEdit1.Text,bitmap);//memoEdit1.Text or your string paragraph
                            }
            }
            private static string AddCommentsToFile_NewPage(string fileName, string userComments, System.Drawing.Bitmap bitmap)
                    {
                        string outputFileName = @"Output_N.pdf";
                        //Step 1: Create a Docuement-Object
                        Document document = new Document();
                        try
                        {
                            //Step 2: we create a writer that listens to the document
                            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFileName, FileMode.Create));
            
                            //Step 3: Open the document
                            document.Open();
            
                            PdfContentByte cb = writer.DirectContent;
            
                            //The current file path
                            string filename = fileName;
            
                            // we create a reader for the document
                            PdfReader reader = new PdfReader(filename);
                            PdfReader.unethicalreading = true;
                            for (int pageNumber = 1; pageNumber < reader.NumberOfPages + 1; pageNumber++)
                            {
                                document.SetPageSize(reader.GetPageSizeWithRotation(1));
                                document.NewPage();
            
                                //Insert to Destination on the first page
                                if (pageNumber == 1)
                                {
                                    Chunk fileRef = new Chunk(" ");
                                    fileRef.SetLocalDestination(filename);
                                    document.Add(fileRef);
                                }
            
                                PdfImportedPage page = writer.GetImportedPage(reader, pageNumber);
                                int rotation = reader.GetPageRotation(pageNumber);
                                if (rotation == 90 || rotation == 270)
                                {
                                    cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(pageNumber).Height);
            
                                }
                                else
                                {
                                    cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                                }
                            }
            
                            // Add a new page to the pdf file
                            document.NewPage();
            
                            Paragraph paragraph = new Paragraph();
                            iTextSharp.text.Font titleFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                      , 15
                                                      , iTextSharp.text.Font.BOLD
                                                      , BaseColor.BLACK
                                );
                            Chunk titleChunk = new Chunk("Reamkrs", titleFont);
                            paragraph.Add(titleChunk);
                            document.Add(paragraph);
            
                            paragraph = new Paragraph();
                            iTextSharp.text.Font textFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                     , 12
                                                     , iTextSharp.text.Font.NORMAL
                                                     , BaseColor.BLACK
                                );
                            Chunk textChunk = new Chunk(userComments, textFont);
                            paragraph.Add(textChunk);
            
                            document.Add(paragraph);
                            paragraph = new Paragraph();
            
                            document.Add(Chunk.NEWLINE);
                            Image logo = Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Bmp);
                            Phrase signature = new Phrase(new Chunk(logo, 0, -10, true));
                            signature.Add(new Chunk(Environment.NewLine));
                            paragraph.Add(signature);
            
                            document.Add(paragraph);
            
            
            
            
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        finally
                        {
                            document.Close();
                        }
                        return outputFileName;
                    }
                    private void AddCommentsToFile_SamePage(string file2, string text, System.Drawing.Bitmap bitmap)
                    {
                        try
                        {
                            PdfReader reader = new PdfReader(new RandomAccessFileOrArray(file2), null);
                            PdfReaderContentParser parser = new PdfReaderContentParser(reader);
                            TextMarginFinder finder = new TextMarginFinder();
                            PdfReader.unethicalreading = true;
            
                            using (PdfStamper stamper = new PdfStamper(reader, new FileStream(@"Output.pdf", FileMode.Create, FileAccess.Write)))
                            {
                                //   int pageNumber = reader.NumberOfPages;
                                //   finder = parser.ProcessContent(pageNumber, new TextMarginFinder());
                                PdfContentByte cb = stamper.GetOverContent(1);
                                Rectangle rect = new Rectangle(0, 0, 0, 0);
                                for (int i = 1; i <= reader.NumberOfPages; i++)
                                {
                                    finder = parser.ProcessContent(i, new TextMarginFinder());
                                    cb = stamper.GetOverContent(i);
                                    rect = new Rectangle(
                                      finder.GetLlx(), finder.GetLly(),
                                      finder.GetWidth() + 90f, finder.GetHeight()
                                    );
                                    cb.Rectangle(rect);
                                }
                                cb.Stroke();
                                //  rect.Height = Size.Height;
                                var size = reader.GetPageSize(1);
                                iTextSharp.text.Font titleFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                      , 15
                                                      , iTextSharp.text.Font.BOLD
                                                      , BaseColor.BLACK
                                );
                                iTextSharp.text.Font textFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                    , 12
                                                    , iTextSharp.text.Font.NORMAL
                                                    , BaseColor.BLACK
                               );
                                Chunk titleChunk = new Chunk("Reamkrs", titleFont);
                                Phrase phrase = new Phrase(text,textFont);
                                // Image logo = Image.GetInstance("signature.png");
                               // System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(40, 60);
                                Image logo = Image.GetInstance(bitmap,System.Drawing.Imaging.ImageFormat.Bmp);
                                Phrase signature = new Phrase(new Chunk(logo,0,0,true));                   
                                ColumnText ct = new ColumnText(cb);
                                ct.SetSimpleColumn(rect);
                                ct.AddElement(titleChunk);
                                ct.AddElement(phrase);
                                ct.AddElement(new Chunk(Environment.NewLine));
                                ct.AddElement(signature);
                                ct.Go();
                                stamper.Close();
                                reader.Close();
                            }
                        }
            
                        catch (Exception ex)
                        {
            
                            MessageBox.Show("sbtn_Click : " + ex.Message);
                        }
                    }
