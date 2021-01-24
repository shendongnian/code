        using (WordprocessingDocument myDocument = WordprocessingDocument.Open(@"C:\Git\source.docx", true))
        {
           foreach (Paragraph objParagraph in myDocument.MainDocumentPart.Document.Body.Elements<Paragraph>())
           {
               string innerText = objParagraph.InnerText;
               string modifiedString = innerText.Replace("<var_Date>", DateTime.Now.ToString("MMM dd,yyyy"));
               if (modifiedString != innerText)
               {
                   Run newRun = new Run();
                   newRun.AppendChild(new Text(modifiedString));
                   objParagraph.RemoveAllChildren<Run>();
                   objParagraph.AppendChild(newRun);
                }
            }
        }
