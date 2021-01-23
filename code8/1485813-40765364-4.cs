    using (var document = WordprocessingDocument.Open("your document path", true))
    {
        //Get the header
        var header = document.MainDocumentPart.HeaderParts.First();
        //These are your paragraphs where you can get the headers Text from
        var paragraphList = header.Header.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
        //Get the imageId
        string imgId = header.GetIdOfPart(header.ImageParts.First());
               
        var imageSource=new BitmapImage();
        //Get the imageStream
        using (var imgStream = ((ImagePart)header.GetPartById(imgId)).GetStream())
        {
            //Copy stream to BitmapImage
            using (var memoryStream = new MemoryStream())
            {
                imgStream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                imageSource.BeginInit();
                imageSource.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                imageSource.CacheOption = BitmapCacheOption.OnLoad;
                imageSource.UriSource = null;
                imageSource.StreamSource = memoryStream;
                imageSource.EndInit();
            }
            imageSource.Freeze();
            //Save BitmapImage to file
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));
            using (var stream = new FileStream("your path for the image.png", FileMode.Create))
                encoder.Save(stream);
        }
    }
