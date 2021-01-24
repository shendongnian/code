    public static void AddPicHeader(string docxFileName) {
        using(WordprocessingDocument doc = WordprocessingDocument.Open(docxFileName, true)) {
            //var mainDocPart = doc.MainDocumentPart;
            //var imgPart = mainDocPart.AddImagePart(ImagePartType.Png, "rId999");
            //var image = GetImageFromFile(logoFileName);
            //var imagePartID = mainDocPart.GetIdOfPart(imgPart);
            //GenerateImagePartContent(imgPart, image);
            if(!mainDocPart.HeaderParts.Any()) {
                mainDocPart.DeleteParts(mainDocPart.HeaderParts);
                var newHeaderPart = mainDocPart.AddNewPart<HeaderPart>();
                // try this insted
                var imgPart = newHeaderPart.AddImagePart(ImagePartType.Png, "rId999");
                              ^^^^^^^^^^^^^
                var image = GetImageFromFile(logoFileName);
                var imagePartID = newHeaderPart.GetIdOfPart(imgPart);
                                  ^^^^^^^^^^^^^
                GenerateImagePartContent(imgPart, image);
                var rId = mainDocPart.GetIdOfPart(newHeaderPart);
                var headerRef = new HeaderReference { Id = rId };
                var sectionProps = doc.MainDocumentPart.Document.Body.Elements<SectionProperties>().LastOrDefault();
                if(sectionProps == null) {
                    sectionProps = new SectionProperties();
                    doc.MainDocumentPart.Document.Body.Append(sectionProps);
                }
                sectionProps.RemoveAllChildren<HeaderReference>();
                sectionProps.Append(headerRef);
                newHeaderPart.Header = GeneratePicHeader(imagePartID);
                newHeaderPart.Header.Save();
            }
        }
    }
