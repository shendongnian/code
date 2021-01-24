    var pathToFile = "D:\\example.pdf";
    var pdfDoc = new PdfDoc(pathToFile); //change it to library that you use for Pdf
    using (var db = new DatabaseContext())
    {
        var fetchCount = 100000; //take size that your hardware can handle with
        var rowCount = db.YourTableName.Count();
        double stepsCount = (rowCount + 0.0)/fetchCount;
        for (int i = 0; i < rowCount/fetchCount; i++)
        {
            var rowsToAdd = db.YourTableName.Skip(i*fetchCount).Take(fetchCount);
            pdfDoc.Append(rowsToAdd); //Use your library method
        }
    }
