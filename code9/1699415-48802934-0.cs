    for (int k = 1; k < dt.Columns.Count; k++)
     {
      Series series = new Series();
      for (int i = 0; i < dt.Rows.Count; i++)
       {
         if ((dt.Rows[i][k]).ToString() != string.Empty)
          {
            float value = Convert.ToSingle(dt.Rows[i][k]);
            series.Points.AddXY("enter_your_seriesname", value);
          }
       }
      hcColumnChart.Series.Add(series);
      hcColumnChart.DataBind();
    }
