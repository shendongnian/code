    public static void OnDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as DatePickerEntryCell;
        if (control != null){
            // do something with this control...
        }
    }
