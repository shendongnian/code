    plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left,AbsoluteMaximum = 190, Maximum = 190,AbsoluteMinimum = 70, Minimum = 70, Title = "Systolic" });
	plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, AbsoluteMaximum = 190, Maximum = 190, AbsoluteMinimum = 40, Minimum = 40, Title = "Diastolic" });
    var series2 = new LineSeries
    {
    MarkerType = MarkerType.Circle,
    MarkerSize = 4,
    MarkerStroke = OxyColors.White
    ;
    if (userInfo != null)
    {
        if (userInfo.Count > 0)
        {
            var counter = 0.00;
            foreach (Info healthData in userInfo)
                {
                    var bp = healthData.BloodPressure;
                    var date = healthData.CreatedDate;
                    var month = date.Month;
                    if (dateLabel != null)
                    {
                        dateLabel.Text = month.ToString();
                    }
                        // TODO Split this blood pressure value
                    var result = Regex.Split(bp,"/");
                    string systolicValue = null;
                    string diastolicValue = null;
                    if (result.Length > 1)
                    {
                        systolicValue = result[0];
                        diastolicValue = result[1];
                    }
                    series2.Points.Add(new DataPoint(double.Parse(diastolicValue), double.Parse(systolicValue)));
					var pointAnnotation1 = new PointAnnotation();  
					pointAnnotation1.X = Convert.ToDouble(diastolicValue);
					pointAnnotation1.Y = Convert.ToDouble(systolicValue);
					pointAnnotation1.Text = String.Format("{0}",date.ToString("MM/dd/yyyy")); // I'm adding the date label here
					plotModel.Annotations.Add(pointAnnotation1);
                   }
				 }
			}
		plotModel.Series.Add(series2);
