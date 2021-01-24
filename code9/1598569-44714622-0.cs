    public Chart GenerateExcChart(DataTable dtChartDataSource, int width, int height, string bgColor, SeriesChartType seriesChartType,
                string axisXTitle, string axisYTitle)
            {
                Chart chart = new Chart()
                {
                    Width = width,
                    Height = height
                };
    
                chart.Legends.Add(new Legend() { Name = "Legend" });
                chart.Legends[0].Docking = Docking.Bottom;
                ChartArea chartArea = new ChartArea() { Name = "ChartArea" };
    
                chartArea.AxisX.MajorGrid.LineWidth = 0;//Remove X-axis grid lines
                chartArea.AxisY.MajorGrid.LineWidth = 0;//Remove Y-axis grid lines
    
                chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chartArea.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chartArea.AxisX.IntervalType = DateTimeIntervalType.Number;
                chartArea.AxisY.IntervalType = DateTimeIntervalType.Number;
    
                chartArea.AxisX.LabelStyle.Angle = -45;
    
                chartArea.AxisX.Title = axisYTitle;
                chartArea.AxisY.Title = axisXTitle;
    
                //Chart Area Back Color
                chartArea.BackColor = Color.FromName(bgColor);
                chart.ChartAreas.Add(chartArea);
                chart.Palette = ChartColorPalette.BrightPastel;
                string series = string.Empty;
    
                //create series and add data points to the series
                if (dtChartDataSource != null)
                {
                    series = "Series1";
                    chart.Series.Add(series);
                    chart.Series[series].ChartType = SeriesChartType.Column;
                    chart.Series[series].XValueType = ChartValueType.Auto;
                    chart.Series[series].YValuesPerPoint = 1;
                    chart.Series[series].YValueType = ChartValueType.Auto;
    
                    var rowIndex = 0;
    
                    //Add data points to the series
                    foreach (DataRow dr in dtChartDataSource.Rows)
                    {
                        double dataPoint;
                        DataPoint objDataPoint = new DataPoint();
    
                        objDataPoint.AxisLabel = dr[dtChartDataSource.Columns[0].ColumnName].ToString();
    
                        double.TryParse(dr[dtChartDataSource.Columns[1].ColumnName].ToString(), out dataPoint);
    
    
                        objDataPoint.XValue = rowIndex;
                        objDataPoint.YValues = new double[] { dataPoint };
    
                        chart.Series[series].Points.Add(objDataPoint);
    
                        rowIndex++;
                    }
                }
    
                chart.Series[0].IsVisibleInLegend = false;
    
                return chart;
            }
