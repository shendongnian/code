    var document = app.ActiveDocument;
    var imageShape = document.InlineShapes[1];
    imageShape.SaveAsImage(Path.Combine(document.Path, "image.jpg"), ImageFormat.Jpeg);
    public static class ImageSaving
    {
        //Based on:http://stackoverflow.com/questions/6512392/how-to-save-word-shapes-to-image-using-vba
        public static void SaveAsImage(this Word.InlineShape inlineShape, string saveAsFileName, ImageFormat imageFormat)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(saveAsFileName));
            var range = inlineShape.Range;
            var bytes = (byte[])range.EnhMetaFileBits;
            //This byte array could simply be saved to a .wmf-file with File.WriteAllBytes()
            using (var stream = new MemoryStream(bytes))
            //Code for resizing based on:  http://stackoverflow.com/questions/7951734/an-unclear-converted-image-wmf-to-png
            using (var metaFile = new Metafile(stream))
            {
                var header = metaFile.GetMetafileHeader();
                //Calculate the scale based on the shape width
                var scale = header.DpiX / inlineShape.Width;
                var width = scale * metaFile.Width / header.DpiX * 100;
                var height = scale * metaFile.Height / header.DpiY * 100;
                using (var bitmap = new Bitmap((int)width, (int)height))
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    graphics.ScaleTransform(scale, scale);
                    graphics.DrawImage(metaFile, 0, 0);
                    //At this point you could do something else with the bitmap than save it
                    bitmap.Save(saveAsFileName, imageFormat);
                }
            }
        }
    }
