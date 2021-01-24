    var valueBinding = new Binding("AttachmentValue")
    {
        Mode = BindingMode.TwoWay,
        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
    };
    newCombobox.SetBinding(ComboBox.SelectedValueProperty, valueBinding);
