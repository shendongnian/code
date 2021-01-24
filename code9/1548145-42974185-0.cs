    var table = new PdfPTable(2) { WidthPercentage = 100 };
    
    foreach (var book_id in books_ids)
    {
      // Book's informations are retrieved from Linq Connect Model.
      var _connection = new LinqtoSQLiteDataContext();
      var book = _connection.books.SingleOrDefault(b_no => b_no.id == book_id);
      // Outer table to get rounded corner...
        
      // Inner table: First cell for QR code and second cell for book's informations.
      var inner_table = new PdfPTable(2) { WidthPercentage = 100 };
      inner_table.DefaultCell.Border = Rectangle.NO_BORDER;
      var inner_measurements = new[] { 40f, 60f };
      inner_table.SetWidths(inner_measurements);
      // Generate QR code in the `Tools` class, `GenerateQR` method.
      System.Drawing.Image image = Tools.GenerateQR(100, 100, book?.isbn);
      var pdfImage = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
      var qr = iTextSharp.text.Image.GetInstance(pdfImage);
      var a = new PdfPCell(qr) { Border = Rectangle.NO_BORDER };
      var b = new PdfPCell(new Phrase(book?.name, font_normal)) { Border = Rectangle.NO_BORDER };
      inner_table.AddCell(a);
      inner_table.AddCell(b);
      PdfPCell labelCell = new PdfPCell(inner_table)
      {
          CellEvent = new RoundRectangle(),
          Border = Rectangle.NO_BORDER,
          Padding = 2,
          HorizontalAlignment = Element.ALIGN_LEFT
      };
      
      table.AddCell(labelCell);               
    }
    
    doc.Add(table);
