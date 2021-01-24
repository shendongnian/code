        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(byteArrayOriginalStream, true))
        {
            //...
            wordDoc.MainDocumentPart.Document.Save();
			wordDoc.Close();
			
            //copy the bytearraystream to outputfilestream
            byteArrayOriginalStream.Seek(0, SeekOrigin.Begin);
            byteArrayOriginalStream.CopyTo(outputStream);
        }
        
