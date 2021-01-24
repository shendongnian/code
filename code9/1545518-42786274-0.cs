    Binding assetsVisibilityBinding = new Binding();
            assetsVisibilityBinding.Source = this;
            assetsVisibilityBinding.Path = new PropertyPath("IsLocalSearchEnabled");
            assetsVisibilityBinding.Mode = BindingMode.TwoWay;
            assetsVisibilityBinding.Converter = Resources["BooleanToVisibilityConverter"] as IValueConverter;
            assetsStackPanel.DataContex=this;
            assetsStackPanel.SetBinding(StackPanel.VisibilityProperty, assetsVisibilityBinding);
