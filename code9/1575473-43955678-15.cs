    public void CreateYAxis(Chart chart, ChartArea area, Series series, 
                            float axisX, float axisWidth, float labelsSize, bool alignLeft)
    {
        chart.ApplyPaletteColors();  // (*)
        // Create new chart area for original series
        ChartArea areaSeries = chart.ChartAreas.Add("CAs_" + series.Name);
        areaSeries.BackColor = Color.Transparent;
        areaSeries.BorderColor = Color.Transparent;
        areaSeries.Position.FromRectangleF(area.Position.ToRectangleF());
        areaSeries.InnerPlotPosition.FromRectangleF(area.InnerPlotPosition.ToRectangleF());
        areaSeries.AxisX.MajorGrid.Enabled = false;
        areaSeries.AxisX.MajorTickMark.Enabled = false;
        areaSeries.AxisX.LabelStyle.Enabled = false;
        areaSeries.AxisY.MajorGrid.Enabled = false;
        areaSeries.AxisY.MajorTickMark.Enabled = false;
        areaSeries.AxisY.LabelStyle.Enabled = false;
        areaSeries.AxisY.IsStartedFromZero = area.AxisY.IsStartedFromZero;
        // associate series with new ca
        series.ChartArea = areaSeries.Name;
        // Create new chart area for axis
        ChartArea areaAxis = chart.ChartAreas.Add("CA_AxY_" + series.ChartArea);
        areaAxis.BackColor = Color.Transparent;
        areaAxis.BorderColor = Color.Transparent;
        RectangleF oRect = area.Position.ToRectangleF();
        areaAxis.Position = new ElementPosition(oRect.X, oRect.Y, axisWidth, oRect.Height);
        areaAxis.InnerPlotPosition
                .FromRectangleF(areaSeries.InnerPlotPosition.ToRectangleF());
        // Create a copy of specified series
        Series seriesCopy = chart.Series.Add(series.Name + "_Copy");
        seriesCopy.ChartType = series.ChartType;
        seriesCopy.YAxisType = alignLeft ? AxisType.Primary : AxisType.Secondary;  // (**)
        foreach (DataPoint point in series.Points)
        {
            seriesCopy.Points.AddXY(point.XValue, point.YValues[0]);
        }
        // Hide copied series
        seriesCopy.IsVisibleInLegend = false;
        seriesCopy.Color = Color.Transparent;
        seriesCopy.BorderColor = Color.Transparent;
        seriesCopy.ChartArea = areaAxis.Name;
        // Disable grid lines & tickmarks
        areaAxis.AxisX.LineWidth = 0;
        areaAxis.AxisX.MajorGrid.Enabled = false;
        areaAxis.AxisX.MajorTickMark.Enabled = false;
        areaAxis.AxisX.LabelStyle.Enabled = false;
        Axis areaAxisAxisY = alignLeft ? areaAxis.AxisY : areaAxis.AxisY2;   // (**)
        areaAxisAxisY.MajorGrid.Enabled = false;
        areaAxisAxisY.IsStartedFromZero = area.AxisY.IsStartedFromZero;
        areaAxisAxisY.LabelStyle.Font = area.AxisY.LabelStyle.Font;
        areaAxisAxisY.Title = series.Name;
        areaAxisAxisY.LineColor =  series.Color;    // (*)
        areaAxisAxisY.TitleForeColor = Color.DarkCyan;  // (*)
        // Adjust area position
        areaAxis.Position.X = axisX;
        areaAxis.InnerPlotPosition.X += labelsSize;
    }
