    using (var document = WordprocessingDocument.Open(@"C:\Test\myTestDocument.docx", false))
    {
    	//just grab all the parts, might be relevant to be a bit more clever about it, depending on sizes of files and how many files you want to search through
        foreach(var part in document.MainDocumentPart.Parts)
        {
    		//foreach part see if that part containts an EmbeddedPackagePart
    		var testForEmbedding = part.OpenXmlPart.GetPartsOfType<EmbeddedPackagePart>();
    		foreach(EmbeddedPackagePart embedding in testForEmbedding)
            {
                //You should probably insert some clever naming scheme here..
                string fileName = embedding.Uri.OriginalString.Split('/').Last();
    			//stream the EmbeddedPackagePart to a file
    			using(FileStream myFile = File.Create(@"C:\test\" + fileName))
                using (var stream = embedding.GetStream())
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(myFile);
    				myFile.Close();
                }
    		}
    	}
    }
