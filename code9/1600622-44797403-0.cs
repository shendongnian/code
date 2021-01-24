    protected void manipulatePdf(String dest) throws Exception {
        PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
        Document doc = new Document(pdfDoc);
 
        Table table = new Table(8);
        for (int i = 0; i < 16; i++) {
            table.addCell("hi");
        }
        doc.add(table);
 
        doc.close();
    }
