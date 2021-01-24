    private void btnCalculate_Click(object sender, EventArgs e)
    {
       try
       {
          int hours = picker1.Value.Hour % 12 +
                      picker2.Value.Hour % 12 +
                      picker3.Value.Hour % 12 +
                      picker4.Value.Hour % 12 +
                      picker5.Value.Hour % 12;
          int minutes = picker1.Value.Minute % 60 +
                        picker2.Value.Minute % 60 +
                        picker3.Value.Minute % 60 +
                        picker4.Value.Minute % 60 +
                        picker5.Value.Minute % 60;
          TimeSpan fromMinutes = TimeSpan.FromMinutes(minutes);
          var ts = hours + fromMinutes.Hours + ":" + fromMinutes.Minutes;
       }
       catch (Exception)
       {
          throw;
       }
    }
