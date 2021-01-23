	// Get the old date
    DateTime currentDateMin = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum);
    // Parse the date you want to set
    DateTime requestesd = DateTime.Parse(textBox1.Text);
    // Set the time part
    DateTime newDateMin = new DateTime(currentDateMin.Year, currentDateMin.Month, currentDateMin.Day, requestesd.Hour, requestesd.Minute, requestesd.Second);
    // Assign to your axis
    chart1.ChartAreas[0].AxisX.Minimum = newDateTime.ToOADate();
