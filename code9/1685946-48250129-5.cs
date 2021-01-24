    class SettingsForm
    {
    
       public static event ColourSettingChangedDelegate ColourSettingsChangedEvent;
       public delegate void ColourSettingChangedDelegate(Color color);
    
       void SelectColour()
       {
          using (ColourForm colourForm = new ColourForm())
          {
             if (colourForm.ShowDialog() == DialogResult.OK)
             {
                //Update colour setting and fire event
                OnColourSettingsChanged(colourForm.SelectedColour);
             }
          }
       }
    
       private void OnColourSettingsChanged(Color color)
       {
          if (ColourSettingsChangedEvent!=null)
            ColourSettingsChangedEvent(color);
       }
    }
