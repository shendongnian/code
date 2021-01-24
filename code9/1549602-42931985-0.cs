            using (WordprocessingDocument doc = WordprocessingDocument.Open(@"filePath", true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }
                Regex regexText = new Regex(@"the", RegexOptions.IgnoreCase);
                docText = regexText.Replace(docText, "New text");
                using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
                doc.MainDocumentPart.Document.Save();               
            }
