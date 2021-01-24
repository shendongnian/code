    void PropertyChanged(object sender, EventArgs e)
    {
        OnValueChanged(sender, e);
    }
    public override void AddValueChanged(object component, EventHandler handler)
    {
        base.AddValueChanged(component, handler);
        ((INotifyPropertyChanged)component).PropertyChanged += PropertyChanged;
    }
    public override void RemoveValueChanged(object component, EventHandler handler)
    {
        base.RemoveValueChanged(component, handler);
        ((INotifyPropertyChanged)component).PropertyChanged -= PropertyChanged;
    }
