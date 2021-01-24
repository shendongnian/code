    Document doc = new Document();
    PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("file6.pdf"), FileMode.Create));
    doc.Open();
    PdfPTable table = new PdfPTable(7);
    
    using (TextFieldParser parser = new TextFieldParser("t.csv"))
    {
    	parser.TextFieldType = FieldType.Delimited;
    	parser.SetDelimiters(",");
    	while (!parser.EndOfData)
    	{
    		//Processing row
    		string[] fields = parser.ReadFields();
    		table.AddCell(new PdfPCell(field[2]);
    		table.AddCell(new PdfPCell(field[3]);
    		table.AddCell(new PdfPCell(field[4]);
    		//......
    	}
    }
    doc.Add(table);
    doc.Close();
