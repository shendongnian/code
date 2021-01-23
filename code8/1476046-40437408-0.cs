    private DateTime? selectedDate;
    public DateTime? SelectedDate
    {
        get
        {
            return selectedDate;
        }
        set
        {
            selectedDate = value;
            RaisePropertyChanged("SelectedDate");
            DateSelectionChangedExecute();
        }
    }
