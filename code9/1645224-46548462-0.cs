    ComboBox cmb = sender as ComboBox;
    double heightOfComboBox = cmb.ActualHeight;
    double heightOfPopup = 0.0;
    Popup popup = cmb.Template.FindName("PART_Popup", cmb) as Popup;
    if (popup != null)
    {
        FrameworkElement fe = popup.Child as FrameworkElement;
        if (fe != null)
            heightOfPopup = fe.ActualHeight;
    }
    double totalHeight = heightOfComboBox + heightOfPopup;
