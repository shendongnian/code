    BaseFont bf = BaseFont.CreateFont(Server.MapPath("~/StudioFonts/EFT_Beigale Heavy.ttf"),
    BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
    Font EFT_Beigale_Heavy = new Font(bf, 40);
    ColumnText column = new ColumnText(writer.DirectContent);
    column.SetSimpleColumn(20, 200, 300, 36);
    column.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
    column.AddElement(new Paragraph(pageContext, EFT_Beigale_Heavy));
    column.Go();
