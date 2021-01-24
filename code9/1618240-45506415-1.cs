        Binding myBinding = new Binding();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            myBinding.Source = model;
            myBinding.Path = new PropertyPath("test");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(txtDeneme, TextBlock.TextProperty, myBinding);
        }
