    PdfDictionary pageDict = pdfReader.GetPageN(1);
    // hide the page rotation
    PdfNumber rotation = pageDict.GetAsNumber(PdfName.ROTATE);
    pageDict.Remove(PdfName.ROTATE);
    //get annotation array
    PdfArray annotArray = pageDict.GetAsArray(PdfName.ANNOTS);
    //iterate through annotation array
    int size = annotArray.Size;
    for (int i = size - 1; i >= 0; i--)
    {
        ...
    }
    // add page rotation again if required
    if (rotation != null)
        pageDict.Put(PdfName.ROTATE, rotation);
    pdfStamper.Close();
