    Selection sel = doc.Application.Selection;
    Table newTable = sel.Tables[1];
    Cell cell_1 = newTable.Cell(1, 1);
    Range oCell1 = cell_1.Range;
    float top1 = sel.get_Information(WdInformation.wdVerticalPositionRelativeToPage);
    float left1 = sel.get_Information(WdInformation.wdHorizontalPositionRelativeToPage);
    cell_1.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
    cell_1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    Interop.Shape shape1 = doc.Shapes.AddShape((int)MsoAutoShapeType.msoShapeCube,
        left1, top1, app.CentimetersToPoints(float.Parse("1.1")),
        app.CentimetersToPoints(float.Parse("0.5")), oCell1);
    shape1.ConvertToInlineShape();
    oCell1.Copy();
            
    Range oCell2 = newTable.Cell(1, 3).Range;
    oCell2.Select();
    oCell2.Paste();
