    private void btnCalculate_Click(object sender, EventArgs e)
    {
       try
       {
          int sum = picker1.Value.Hour + picker1.Value.Minute +
                    picker2.Value.Hour + picker2.Value.Minute +
                    picker3.Value.Hour + picker3.Value.Minute +
                    picker4.Value.Hour + picker4.Value.Minute;
          txtSum.Text = sum.ToString();
       }
       catch (Exception)
       {
          throw;
       }
    }
