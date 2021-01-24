    class ColourForm()
    {
        //Constructor
        ColourForm()
        {
           SettingsForm.ColourSettingsChangedEvent += ColourSettingsChanged;
        }
    
        void ColourSettingsChanged(Color color)
        {
          upperpanel.BackColor = color;
        }
    }
