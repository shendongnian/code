    private void ConvertToPdf()
    {
        try
        {
            for (int i = 0; i < listOfDocx.Count; i++)
            {
                CurrentModalText = "Converting To PDF";
                CurrentLoadingNum += 1;
                string savePath = PdfTempStorage + i + ".pdf";
                listOfPDF.Add(savePath);
                Spire.Doc.Document document = new Spire.Doc.Document(listOfDocx[i], FileFormat.Auto);
                document.SaveToFile(savePath, FileFormat.PDF);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }
