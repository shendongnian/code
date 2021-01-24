    Document pdfDocument = new Document();
    System.Drawing.Image img = new Bitmap(dataDir + "your-image.jpg");
    Watermark wm = new Watermark(img, new Rectangle(50, 100, 100, 200));
    pdfDocument.Pages.Add().Watermark = wm;
    pdfDocument.Save(dataDir + "output.pdf");
    pdfDocument = new Document(dataDir + "output.pdf");
    foreach (Artifact artifact in pdfDocument.Pages[1].Artifacts)
    {
     Console.WriteLine(artifact.Subtype + " " + artifact.Text + " " + artifact.Rectangle);
    }
