    private static void Edit()
    {
    
       setForeColor(drives1.Controls);
       setForeColor(ipAdd1.Controls);
       setForeColor(spotify1.Controls);
       setForeColor(timeAndDate1.Controls);
       setForeColor(activeWindow1.Controls);
       setForeColor(reminders11.Controls);
       setForeColor(weather1.Controls);
    
    }
    
    
    private static void setForeColor(Controls controls)
    {
            foreach (Control c in controls)
            {
                if (c.Name.StartsWith("SC"))
                { 
                    c.ForeColor = Color.FromArgb(rr, gg, bb); 
                }
            }
    
    }
