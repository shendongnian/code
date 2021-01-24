        LegendItem item1 = new LegendItem();
        item1.ImageStyle = LegendImageStyle.Rectangle;
        item1.Color = Color.Red;
        item1.BorderColor = Color.Red;
        item1.Cells.Add(LegendCellType.SeriesSymbol, "", ContentAlignment.MiddleCenter);
        item1.Cells.Add(LegendCellType.Text, "Low Bed Number", ContentAlignment.MiddleLeft);
        ChartClass.Legends[0].CustomItems.Add(item1);
