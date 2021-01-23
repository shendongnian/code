    var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", 
                         "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    for (int i = 0; i < pointCount; i++)
    {
        double sum = 0;
        string label = "";
        for (int j = 0; j < seriesCount; j++)
        {
            sum += chart.Series[j].Points[i].YValues[0];
            label += "\\n" + +chart.Series[j].Points[i].YValues[0] ;
        }
        chart.Series[0].Points[i].AxisLabel = months[i] + "\\n"  + sum + label;
    }
