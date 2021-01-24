    //Takes 0ms?
    foreach(Range cell in ur.Cells)
    {
        if(cell.Interior.Pattern == -4142)
        {
            b = b!=null ? application.Union(b, cell) : cell;
        }
    }
    b.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    b.Borders[XlBordersIndex.xlEdgeBottom].ThemeColor = 3;
    b.Borders[XlBordersIndex.xlEdgeBottom].Weight = 2;
    b.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
    b.Borders[XlBordersIndex.xlEdgeTop].ThemeColor = 3;
    b.Borders[XlBordersIndex.xlEdgeTop].Weight = 2;
    b.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
    b.Borders[XlBordersIndex.xlEdgeLeft].ThemeColor = 3;
    b.Borders[XlBordersIndex.xlEdgeLeft].Weight = 2;
    b.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
    b.Borders[XlBordersIndex.xlEdgeRight].ThemeColor = 3;
    b.Borders[XlBordersIndex.xlEdgeRight].Weight = 2;
    b.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
    b.Borders[XlBordersIndex.xlInsideHorizontal].ThemeColor = 3;
    b.Borders[XlBordersIndex.xlInsideHorizontal].Weight = 2;
    b.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
    b.Borders[XlBordersIndex.xlInsideVertical].ThemeColor = 3;
    b.Borders[XlBordersIndex.xlInsideVertical].Weight = 2;
