    TableLayoutColumnStyleCollection styles =
    tableLayoutPanel1.ColumnStyles;
    
    foreach (ColumnStyle style in styles){
       // Set the column width to 20 pixels.
       style.SizeType = SizeType.Absolute;
       style.Width = 20;
    }
