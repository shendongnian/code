    foreach(var item in SelectedQualificationType.QualificationTypeInputFields.QualificationTypeFields)
    {
        item.PropertyChanged += item_PropertyChanged;   
    }
           
    ...
    private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Value")
        {
            ExecuteExpressionsCommand.Execute(null);
        }
    }
