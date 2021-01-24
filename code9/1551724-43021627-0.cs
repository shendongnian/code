        using Microsoft.Office.Interop.Word;
        public List<Image> GetImages(Document doc,Microsoft.Office.Interop.Word.Application app)
        {
            List<Image> images = new List<Image>();
            for (var i = 1; i <= app.ActiveDocument.InlineShapes.Count; i++)
            {
                 var inlineShapeId = i;
               
               
                 images.Add(SaveInlineShapeToFile(inlineShapeId, app));
                // STA is needed in order to access the clipboard
            
            }
           
             return images;
        }
            private Image SaveInlineShapeToFile(int inlineShapeId, Microsoft.Office.Interop.Word.Application app)
        {
            var inlineShape = app.ActiveDocument.InlineShapes[inlineShapeId];
            inlineShape.Select();
           app.Selection.Copy();
            // Check data is in the clipboard
            if (Clipboard.GetDataObject() != null)
            {
                var data = Clipboard.GetDataObject();
                // Check if the data conforms to a bitmap format
                if (data != null && data.GetDataPresent(DataFormats.Bitmap))
                {
                    // Fetch the image and convert it to a Bitmap
                    Image image = (Image)data.GetData(DataFormats.Bitmap, true);
                    return image;
                }
            }
            return null;
        }
