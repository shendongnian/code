      public void OpenWordprocessingDocumentReadonly()
            {
                string filepath = @"C:\...\test.docx";
                // Open a WordprocessingDocument based on a filepath.
                Dictionary<int, string> pageviseContent = new Dictionary<int, string>();
                int pageCount = 0;
                using (WordprocessingDocument wordDocument =
                    WordprocessingDocument.Open(filepath, false))
                {
                    // Assign a reference to the existing document body.  
                    Body body = wordDocument.MainDocumentPart.Document.Body;
                    if (wordDocument.ExtendedFilePropertiesPart.Properties.Pages.Text != null)
                    {
                        pageCount = Convert.ToInt32(wordDocument.ExtendedFilePropertiesPart.Properties.Pages.Text);
                    }
                    int i = 1;
                    StringBuilder pageContentBuilder = new StringBuilder();
                    foreach (var element in body.ChildElements)
                    {
                        if (element.InnerXml.IndexOf("<w:br w:type=\"page\" />", StringComparison.OrdinalIgnoreCase) < 0)
                        {
                            pageContentBuilder.Append(element.InnerText);
                        }
                        else
                        {
                            pageviseContent.Add(i, pageContentBuilder.ToString());
                            i++;
                            pageContentBuilder = new StringBuilder();
                        }
                        if (body.LastChild == element && pageContentBuilder.Length > 0)
                        {
                            pageviseContent.Add(i, pageContentBuilder.ToString());
                        }
                    }
                }
            }
