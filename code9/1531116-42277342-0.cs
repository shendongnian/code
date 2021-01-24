      private void dtP1_ValueChanged(object sender, EventArgs e)
            {
                var days = DayOfWeek.Monday - dtP1.Value.DayOfWeek;
    
                if (dtP1.Value.DayOfWeek != DayOfWeek.Monday)
                {
                    dtP1.Value = new DateTime(dtP1.Value.Year, dtP1.Value.Month, dtP1.Value.Day + days);
                }
    
            }
