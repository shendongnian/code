    PdfPTable table1 = new PdfPTable(2);
    table1.DefaultCell.Border = Rectangle.NO_BORDER;
    table1.WidthPercentage = 100;
    PdfPCell cell11 = new PdfPCell();
    Paragraph UniName = new Paragraph(@"TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐỒNG NAI", fontBold);
    UniName.Alignment = Element.ALIGN_CENTER;
    Paragraph paragraph = new Paragraph(@"PHÒNG ĐÀO TẠO", times);
    paragraph.Alignment = Element.ALIGN_CENTER;
    cell11.AddElement(UniName);
    cell11.AddElement(paragraph);
    cell11.BorderColor = BaseColor.WHITE;
    PdfPCell cell12 = new PdfPCell();
    Paragraph QH1 = new Paragraph(@"CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontBold);
    QH1.Alignment = Element.ALIGN_CENTER;
    Paragraph QH = new Paragraph(@"Độc lập - Tự do - Hạnh phúc", fontBold);
    QH.Alignment = Element.ALIGN_CENTER;
    Paragraph Symbol = new Paragraph(@"----------oOo----------", fontBold);
    Symbol.Alignment = Element.ALIGN_CENTER;
    cell12.AddElement(QH1);
    cell12.AddElement(QH);
    cell12.AddElement(Symbol);
    cell12.BorderColor = BaseColor.WHITE;
    table1.AddCell(cell11);
    table1.AddCell(cell12);
    Paragraph TitleReport = new Paragraph(@"TỔNG HỢP COI CHẤM THI", titleFont);
    TitleReport.Alignment = Element.ALIGN_CENTER;
    Paragraph Info = new Paragraph(string.Format(@"Từ ngày: {0}     đến ngày: {1}        Đơn vị: {2}", DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), "Trung tâm quản lý chất lượng"), normalFont);
    Info.Alignment = Element.ALIGN_LEFT;
    Info.SpacingBefore = 20;
    Info.SpacingAfter = 200;
    doc.Add(table1);
    doc.Add(TitleReport);
    doc.Add(Info);
    float afterHeaderY = writer.GetVerticalPosition(true);
    Rectangle[] COLUMNS = new Rectangle[] {
        new Rectangle(36, 36, 290, afterHeaderY),
        new Rectangle(305, 36, 559, afterHeaderY)
    };
    PdfContentByte canvas = writer.DirectContent;
    ColumnText ct = new ColumnText(canvas);
    int side_of_the_page = 0;
    ct.SetSimpleColumn(COLUMNS[side_of_the_page]);
    PdfPTable table = new PdfPTable(5);
    table.AddCell("STT");
    table.AddCell("Số Phách");
    table.AddCell("Điểm bằng số");
    table.AddCell("Điểm bằng chữ");
    table.AddCell("Ghi chú");
    for (int i = 0; i < 33; i++)
    {
        table.AddCell((i + 1).ToString());
        table.AddCell("209292");
        table.AddCell("4");
        table.AddCell("Điểm bằng chữ");
        table.AddCell("");
    }
    table.HeaderRows = 1;
    ct.AddElement(table);
    while (ColumnText.HasMoreText(ct.Go()))
    {
        if (side_of_the_page == 0)
        {
            side_of_the_page = 1;
            canvas.MoveTo(297.5f, 36);
            canvas.LineTo(297.5f, afterHeaderY);
            canvas.Stroke();
        }
        else
        {
            side_of_the_page = 0;
            doc.NewPage();
            COLUMNS = new Rectangle[] {
                new Rectangle(36, 36, 290, 806),
                new Rectangle(305, 36, 559, 806)
            };
            afterHeaderY = 806;
        }
        ct.SetSimpleColumn(COLUMNS[side_of_the_page]);
    }
