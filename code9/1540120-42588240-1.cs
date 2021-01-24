    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=charts.pdf");
    using (Document document = new Document())
    {
        PdfWriter.GetInstance(document, Response.OutputStream);
        document.Open();
        document.Add(Image.GetInstance(GetChartImage(3, 5, 7)));
        document.Add(Image.GetInstance(GetChartImage(2, 4, 6, 8)));
    }
    Response.End();
