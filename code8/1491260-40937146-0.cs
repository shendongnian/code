    public partial class Master2 : BaseMasterPage
    {
      public event EventHandler CalendarSelectionChanged;
    
      public void Calendar_OnSelectionChanged(object sender, EventArgs e)
      {
            OnCalendar_SelectionChanged_CustomEvent(e);
    
          ///.....
      }
     public virtual void OnCalendar_SelectionChanged_CustomEvent(EventArgs e)
        {
            if (Calendar_SelectionChanged_CustomEvent != null)
                Calendar_SelectionChanged_CustomEvent(this, EventArgs.Empty);
        }
    }
