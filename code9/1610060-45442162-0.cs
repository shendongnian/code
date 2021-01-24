                FileInfo file = new FileInfo(textBox2.Text);
                using (PdfReader reader = new PdfReader(textBox2.Text))
                {
                    for (int pagenumber = 1; pagenumber <= reader.NumberOfPages; pagenumber++)
                    {
                        string filename = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                        Document document = new Document();                                            
                        if(PdfTextExtractor.GetTextFromPage(reader, pagenumber, new SimpleTextExtractionStrategy()).Contains("LoremIpsum"))
                        {
                            PdfCopy copy = new PdfCopy(document, new FileStream(textBox3.Text + "\\" + filename + pagenumber + ".pdf", FileMode.Create));
                            document.Open();
                            copy.AddPage(copy.GetImportedPage(reader, pagenumber));
                            document.Close();
                        }
                        
                    }
                }
