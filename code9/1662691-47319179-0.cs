    private void run_Click(object sender, EventArgs e)
    {
        Document doc = new Document(PageSize.A4);
        using(FileStream op = new FileStream("text.pdf", FileMode.Create))
        {
            PdfWriter wri = PdfWriter.GetInstance(doc, op);
            Paragraph p = new Paragraph("test");
            doc.Open();
            doc.Add(p);
        }
        using (FileStream op = new FileStream("text.pdf", FileMode.Append, FileAccess.Write))
        {
            doc = new Document(PageSize.A4); // this is the fix
            PdfWriter wri = PdfWriter.GetInstance(doc, op);
            Paragraph p = new Paragraph("test2");
            doc.Open();
            doc.Add(p);
            doc.Close();
        }
    }
