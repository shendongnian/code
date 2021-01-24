    <CheckBox IsChecked="{Binding Path=CB_1_Checked}" Content="CheckBox 1" />
    public bool CB_1_Checked 
    {
       get { return _cb_1_checked; }
       set
       {
           _cb_1_checked = value;
           OnPropertyChanged();
       }
    }
