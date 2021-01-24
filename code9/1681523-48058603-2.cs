    var diagram = worksheet.Drawings.AddChart("chart", eChartType.ColumnClustered);
           
    for (int i = 2; i <= row; i++)
     {
      var series = diagram.Series.Add($"B{i}:C{i}", "B1:C1");
      series.Header = worksheet.Cells[$"A{i}"].Value.ToString();
     }
    diagram.Border.Fill.Color = System.Drawing.Color.Green;
