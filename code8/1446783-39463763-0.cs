    private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                string value = (string)e.NewValue;
                string Name = value.Split(new char[] { ':' })[1].Split(new char[] { '(' })[0].Trim();
                string ID = value.Split(new char[] { ':' })[1].Split(new char[] { '(' })[1].Split(new char[] { ')' })[0].Trim();
                string formatting = BindingOperations.GetMultiBinding(d, MyButton.MyPropertyProperty).StringFormat;
            }
