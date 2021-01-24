    private void button1_Click(object sender, RibbonControlEventArgs e)
            {
                var fileFullName = Globals.ThisAddIn.Application.ActiveDocument.FullName;
    
                Globals.ThisAddIn.Application.ActiveDocument.Close(WdSaveOptions.wdSaveChanges, WdOriginalFormat.wdOriginalDocumentFormat, true);
    
    
                OpenAndAddTextToWordDocument(fileFullName, "[USER_NAME]");
                
    
                Globals.ThisAddIn.Application.Documents.Open(fileFullName);
            }
    
            public static void OpenAndAddTextToWordDocument(string filepath, string txt)
            {
                // Open a WordprocessingDocument for editing using the filepath.
                WordprocessingDocument wordprocessingDocument =
                    WordprocessingDocument.Open(filepath, true);
    
                // Assign a reference to the existing document body.
                Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
    
                // Add new text.
                DocumentFormat.OpenXml.Wordprocessing.Paragraph para = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text(txt));
    
                // Close the handle explicitly.
                wordprocessingDocument.Close();
            }
    
        }
