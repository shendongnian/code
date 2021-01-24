    string sourceMultiPage = PATH_OF_THE_MULTIPAGE_PDF;
    string sourceSinglePage = PATH_OF_THE_SINGLEPAGE_PDF;
    string dest = PATH_OF_THE_RESULT;
    using (PdfReader readerSingle = new PdfReader(sourceSinglePage))
    using (PdfReader readerMulti = new PdfReader(sourceMultiPage))
    using (PdfStamper stamper = new PdfStamper(readerMulti, new FileStream(dest, FileMode.Create)))
    {
        PdfImportedPage singlePage = stamper.GetImportedPage(readerSingle, 1);
        Rectangle pageRect = readerSingle.GetPageSizeWithRotation(1);
        for (int page = readerMulti.NumberOfPages + 1; page > 1; page--)
        {
            stamper.InsertPage(page, pageRect);
            stamper.GetOverContent(page).AddTemplate(singlePage, pageRect.Left, pageRect.Bottom);
        }
    }
