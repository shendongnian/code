    PdfReader reader = new PdfReader(pdf);
    PdfReaderContentParser parser = new PdfReaderContentParser(reader);
    MyImageRenderListener listener = new MyImageRenderListener();
    for (int i = 1; i <= reader.NumberOfPages; i++) {
      parser.ProcessContent(i, listener);
    } 
    // Process images in the List listener.MyImages
    // with names in listener.ImageNames
