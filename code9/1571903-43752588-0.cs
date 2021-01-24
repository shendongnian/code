    //Loads the PDF document
    PdfDocument doc = new PdfDocument("Image.pdf");
    //Disables the incremental update
    doc.FileInfo.IncrementalUpdate = false;
    
    //Traverses all pages
    foreach (PdfPageBase page in doc.Pages)
    {
        //Extracts images from page
        Image[] images = page.ExtractImages();
        if (images != null && images.Length > 0)
        {
            //Traverses all images
            for (int j = 0; j < images.Length; j++)
            {
                Image image = images[j];
                PdfBitmap bp = new PdfBitmap(image);
                //Reduces the quality of the image
                bp.Quality = 20;
                //Replaces the old image in the document with the compressed image
                page.ReplaceImage(j, bp);
            }
        }                
    }
    //Saves and closes the resultant document
    doc.SaveToFile("Output.pdf");
    doc.Close();
