    TextBox nameTextBox = new TextBox();
    Binding nameTextBinding = new Binding("Name");
    nameTextBinding.Source = person;
    nameTextBinding.Mode = BindingMode.TwoWay;   
    nameTextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
 
    nameTextBox.SetBinding(TextBox.TextProperty, nameTextBinding);
