      var document = new Document();
      var page = document.AddSection();
      Table table = page.AddTable();
      table.Borders.Visible = true;
      Column col = table.AddColumn("3cm");
      col = table.AddColumn("10cm");
      col = table.AddColumn("3cm");
      col.Format.Alignment = ParagraphAlignment.Left;
      Row row = table.AddRow();
      Paragraph p = row.Cells[0].AddParagraph();
      p.AddFormattedText("Top header row");
      row.Cells[0].MergeRight = 2;
      // then set it in visible as false like this, you can do top, left and right as well
      row.Cells[0].Borders.Bottom.Visible = false;
