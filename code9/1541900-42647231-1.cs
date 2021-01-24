    private void btnCalculate_Click(object sender, EventArgs e)
    {
       try
       {
          int sum = picker1.Value.Hour + picker1.Value.Minute +
                    picker2.Value.Hour + picker2.Value.Minute +
                    picker3.Value.Hour + picker3.Value.Minute +
                    picker4.Value.Hour + picker4.Value.Minute;
          txtSum.Text = sum.ToString();
          
          TimeSpan result = TimeSpan.FromHours(Convert.ToInt32(txtSum.Text));
          string fromTimeString = result.ToString("hh':'mm");
       }
       catch (Exception)
       {
          throw;
       }
    }
