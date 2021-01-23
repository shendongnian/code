    if (tbObjects.Text == "")
    {
        Binding myBinding = new Binding("[Var1]");
        myBinding.Source = TranslationSource.Instance;
        myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        BindingOperations.SetBinding(tbObjects, TextBox.TextProperty, myBinding);
        tbObjects.Foreground = new SolidColorBrush(Colors.Gray);
    }
