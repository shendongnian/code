    SharedMethod(EnglishPicker, "English");
    SharedMethod(PhotographyPicker, "Photography");
    
    // ...
    
    private void SharedMethod(PickerClass picker, string settingName)
    {
        var labelFirst = picker.SelectedColorText.Substring(0, 1);
        var labelLast = picker.SelectedColorText.Substring(3, 6);
        var label = labelFirst + labelLast;
        UpdateSetting(settingName, label);
    }
