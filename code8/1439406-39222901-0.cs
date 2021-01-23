    public bool AddParagraph(Paragraph p, PdfContentByte canvas, 
        AcroFields.FieldPosition f, bool simulate) 
    {
      ColumnText ct = new ColumnText(canvas);
      ct.SetSimpleColumn(
        f.position.Left, f.position.GetBottom(2),
        f.position.GetRight(2), f.position.Top
      );
      ct.AddElement(p);
      return ColumnText.HasMoreText(ct.Go(simulate));
    }
