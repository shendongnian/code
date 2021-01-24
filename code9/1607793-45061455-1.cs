        public void manipulatePdf(String dest) {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            Document doc = new Document(pdfDoc);
            Rectangle rect = new Rectangle(100, 400, 400, 400);
            PdfStream stream3D = new PdfStream(pdfDoc, new FileInputStream(RESOURCE));
            stream3D.Put(PdfName.Type, new PdfName("3D"));
            stream3D.Put(PdfName.Subtype, new PdfName("U3D"));
            stream3D.SetCompressionLevel(CompressionConstants.DEFAULT_COMPRESSION);
            stream3D.Flush();
            PdfDictionary dict3D = new PdfDictionary();
            dict3D.Put(PdfName.Type, new PdfName("3DView"));
            dict3D.Put(new PdfName("XN"), new PdfString("Default"));
            dict3D.Put(new PdfName("IN"), new PdfString("Unnamed"));
            dict3D.Put(new PdfName("MS"), PdfName.M);
            dict3D.Put(new PdfName("C2W"),
                    new PdfArray(new float[] { 1, 0, 0, 0, 0, -1, 0, 1, 0, 3, -235, 28 }));
            dict3D.Put(PdfName.CO, new PdfNumber(235));
            Pdf3DAnnotation annot = new Pdf3DAnnotation(rect, stream3D);
            annot.SetContents(new PdfString("3D Model"));
            annot.SetDefaultInitialView(dict3D);
            pdfDoc.AddNewPage().AddAnnotation(annot);
            doc.Close();
        }
