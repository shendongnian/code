    protected void poDateCalendar_DayRender(object sender, DayRenderEventArgs e)
    {
         if (e.Day.Date < DateTime.Today)
         {
             e.Day.IsSelectable = false;
             // Additionally grey out dates if you want
         }
    }
 
