    WeekDays wd = WeekDays.None;
    
    foreach (CheckBox checkBox in this.Controls.OfType<CheckBox>())
    {   
        if (checkBox.IsChecked)
            wd |= (WeekDays)Enum.Parse(typeof(WeekDays), checkBox.Name.Replace("CheckBox", ""));
        
    }
