    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
     int[] arOfDaysInOrange = { 9, 10, 19, 20, 29, 30 };
     if (arOfDaysInOrange.Contains(Convert.ToInt32(e.Day.DayNumberText)))
      e.Cell.BackColor = System.Drawing.Color.DarkOrange;
     else
      e.Cell.BackColor = System.Drawing.Color.DarkGreen;
    }
