    private GenericCombobox selectedType;
    public GenericCombobox SelectedType
    {
        get { return selectedType; }
        set { this.RaiseAndSetIfChanged(ref selectedType, value); }
    }
