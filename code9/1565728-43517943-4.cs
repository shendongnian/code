            Binding bind=new Binding()
            {
                 Path = new PropertyPath("Result"),
            };
            bind.Source = ViewModel;
            bind.Mode=BindingMode.OneWay;
            BindingOperations.SetBinding(TextBox,TextBox.TextProperty, bind);
