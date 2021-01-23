    var series = Mainchart.Series[0]; //series object
                    var chartArea = Mainchart.ChartAreas[series.ChartArea];
                    chartArea.AxisX.StripLines.Add(new StripLine
                    {
                        BorderDashStyle = ChartDashStyle.Solid,
                        BorderColor = Color.Black,
                        Interval = 0, // to show only one vertical line
                        IntervalOffset = 1.5, // for showing Vertical line between 2 series 
                        IntervalType = DateTimeIntervalType.Years // for me years
                    });
