    class MainForm()
    {
        //Constructor
        MainForm()
        {
           SettingsForm.ColourSettingsChangedEvent += ColourSettingsChanged;
        }
    
        void ColourSettingsChanged(Color color)
        {
          upperpanel.BackColor = color;
        }
    }
