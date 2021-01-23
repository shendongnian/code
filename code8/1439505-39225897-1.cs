        DateTime start = DateTime.ParseExact(txtStartTime.Text.Trim(),"HH:mm", null);
        DateTime end = DateTime.ParseExact(txtEndTime.Text.Trim(), "HH:mm", null);
        if (end < start)
        {
            end = end.AddDays(1);
        }
        
        int interval = Convert.ToInt32(txtSessionDuration.Text.Trim());
        for (DateTime i = start; i < end; i = i.AddMinutes(interval)) 
        {
               //some code goes here...
        }
