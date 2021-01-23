          void CheckBox_Loaded(object sender, RoutedEventArgs e)
          {
              Binding b = new Binding();
              b.Path = new PropertyPath("isChecked");
              b.Mode = BindingMode.TwoWay;
              b.Source = this;
              CheckBox cb = sender as CheckBox;
              BindingOperations.SetBinding(cb , CheckBox.IsCheckedProperty, b);
          }
