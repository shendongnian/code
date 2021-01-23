           ChartCustomPoint cp1 = new ChartCustomPoint();
           // Point that follows a series point:
           cp1.PointIndex = 2;
           cp1.SeriesIndex = 0;
           cp1.CustomType = ChartCustomPointType.PointFollow;
           cp1.Symbol.Shape = ChartSymbolShape.Circle;
           cp1.Offset = 20;
           cp1.Font.Facename = "Times New Roman";
           cp1.Font.Bold = true;
           cp1.Font.Size = 11f;
           cp1.Symbol.Color = Color.FromArgb(0Xc1, 0X39, 0x2b);
           // Provide space between the symbol and the text
           cp1.Alignment = ChartTextOrientation.RegionUp;
           cp1.Text = "Circle";
           cp1.Symbol.Marker.LineInfo.Width = 4;
           chart.CustomPoints.Add(cp1);
      
