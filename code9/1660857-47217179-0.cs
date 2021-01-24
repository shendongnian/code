    public string UploadImages(Stream imgstram)
        {
            var parser = new MultipartFormDataParser(imgstram);
            foreach (var file in parser.Files)
            {
                //file => stream of single image.
                //convert stream to image
            }
        }
