    public VM()
    {
        this.Collection = new ObservableCollection<string>(new string[] { "A", "B", "C" });
        this.Selected = "A";
        //  Take aim at foot...
        //this.PropertyChanged += VM_PropertyChanged;
    }
    void VM_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //  ...pull trigger. 
        this.Selected = "C";
    }
