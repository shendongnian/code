    set
    {
        lbl_PopupTitle.Text = value;
        lbl_PopupTitle.Visibility = string.IsNullOrEmpty(value) ? Visibility.Collapsed : Visibility.Visible;
    }
