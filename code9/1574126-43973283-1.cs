    using (var ppt = PresentationDocument.Open(powerPointFilePath, true))
    {
        foreach (var slide in slides)
        {
            //Remove Ole Objects
            var oleObjectCount = slide.Slide.Descendants<OleObject>().Count();
            while (oleObjectCount > 0)
            {
                var oleObj = slide.Slide.Descendants<OleObject>().FirstOrDefault();
                var oleObjGraphicFrame = oleObj?.Ancestors<GraphicFrame>().FirstOrDefault();
                if (oleObjGraphicFrame != null)
                {
                    oleObjGraphicFrame.RemoveAllChildren();
                    oleObjGraphicFrame.Remove();
                }
                oleObjectCount = slide.Slide.Descendants<OleObject>().Count();
            }
            //Delete embedded objects
            slide.DeleteParts(slide.EmbeddedObjectParts);
            //Delete all pictures
            slide.DeleteParts(slide.ImageParts);
        }
    }
