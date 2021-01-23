    public static void CreateDoc(string fileName)
    {
        // Create a Wordprocessing document. 
        using (WordprocessingDocument package = 
                 WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
        {
            // Add a new main document part. 
            package.AddMainDocumentPart();
            //create a body and a paragraph
            Body body = new Body();
            Paragraph paragraph = new Paragraph();
            //add the first part of the text to the paragraph in a Run
            paragraph.AppendChild(new Run(new Text("This sentence has spacing between the gg in to")));
            //create another run to hold the text with spacing
            Run secondRun = new Run();
            //create a RunProperties with a Spacing child.
            RunProperties runProps = new RunProperties();
            runProps.AppendChild(new Spacing() { Val = 80 });
            //append the run properties to the Run we wish to assign spacing to
            secondRun.AppendChild(runProps);
            //add the text to the Run
            secondRun.AppendChild(new Text("gg"));
            //add the spaced Run to the paragraph
            paragraph.AppendChild(secondRun);
            //add the final text as a third Run
            paragraph.AppendChild(new Run(new Text("ling")));
            //add the paragraph to the body
            body.AppendChild(paragraph);
            package.MainDocumentPart.Document = new Document(body);
                
            // Save changes to the main document part. 
            package.MainDocumentPart.Document.Save();
        }
    }
