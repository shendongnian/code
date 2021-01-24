    //using Ovml = DocumentFormat.OpenXml.Vml.Office;
    //Determine whether there are any Embedded Objects in the document
    using (var wdDoc = WordprocessingDocument.Open(wordFilePath, true))
    {
        var docPart = wdDoc.MainDocumentPart;
        var docHasEmbeddedOleObjects = document.Body.Descendants<Ovml.OleObject>().Any();
        if (docHasEmbeddedOleObjects)
        {
            foreach (var oleObj in document.Body.Descendants<Ovml.OleObject>())
            {
                oleObj.Remove(); //Remove each ole object in the document. This will remove the object from view in word.
            }
            //Delete the embedded objects. This will remove the actual attached files from the document.
            docPart.DeleteParts(docPart.EmbeddedObjectParts);
            //Delete all picture in the document
            docPart.DeleteParts(docPart.ImageParts);
        }
    }
