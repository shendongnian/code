    Font bodyFont = FontFactory.GetFont("Times New Roman", 10, Font.NORMAL);
    file.Directory.Create();
    //Initialize PDF writer
    PdfWriter writer = new PdfWriter(DEST);
    //Initialize PDF document
    PdfDocument pdf = new PdfDocument(writer);
    // Initialize document
    Document doc = new Document(pdf); 
    
    doc.Add(new Paragraph("Test", bodyFont));
    doc.Add(new Paragraph("    Test", bodyFont));
    doc.Add(new Paragraph("  Test", bodyFont));
    doc.Add(new Paragraph("        Test 1 2   2", bodyFont));
    doc.Close();
