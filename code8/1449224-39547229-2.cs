    public void UpdateData(double[,] data)
    {
        series.Data = data;
                        
        //adjust date/time axis
        int numOfMinutes = data.GetLength(1);            
        dateTimeAxis.Minimum = DateTimeAxis.ToDouble(DateTime.Now);
        dateTimeAxis.Maximum DateTimeAxis.ToDouble(DateTime.Now.AddMinutes(numOfMinutes));
     }
