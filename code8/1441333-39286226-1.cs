    private void fillChart()
    {
        //AddXY value in chart1 in series named as Salary  
        chart1.Series["Salary"].Points.AddXY("Ajay", "10000");
        chart1.Series["Salary"].Points.AddXY("Ramesh", "8000");
        chart1.Series["Salary"].Points.AddXY("Ankit", "7000");
        chart1.Series["Salary"].Points.AddXY("Gurmeet", "10000");
        chart1.Series["Salary"].Points.AddXY("Suresh", "8500");
        //chart title  
        chart1.Titles.Add("Salary Chart"); 
        //These lines will show percentages.
        chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{#}%"; 
        chart1.Series["Salary"].IsValueShownAsLabel = true;
        chart1.Series["Salary"].LabelFormat = "{#}%"; 
    }
