    using (WordprocessingDocument document = WordprocessingDocument.Open(filename, true))
    {
        foreach (HeaderPart headerPart in document.MainDocumentPart.HeaderParts)
        {
            List<ImagePart> list = new List<ImagePart>();
            List<ImagePart> imgParts = new List<ImagePart>(headerPart.ImageParts);
            List<Drawing> drwdDeleteParts = new List<Drawing>();
            List<Drawing> drwParts = new List<Drawing>(headerPart.RootElement.Descendants<Drawing>());
            foreach (ImagePart headerImagePart in imgParts)
            {
                string newUri = headerImagePart.Uri.ToString();
                if (newUri != uri)
                {
                    list.Add(headerImagePart);
                    //you also need to find the Drawings the image was related to
                    IEnumerable<Drawing> drawings = drwParts.Where(d => d.Descendants<Pic.Picture>().Any(p => p.BlipFill.Blip.Embed == headerPart.GetIdOfPart(headerImagePart)));
                    foreach (var drawing in drawings)
                    {
                        if (drawing != null && !drwdDeleteParts.Contains(drawing))
                            drwdDeleteParts.Add(drawing);
                    }
                }
            }
            foreach (var d in drwdDeleteParts)
            {
                d.Remove();
            }
            headerPart.DeleteParts(list);
        }
    }
