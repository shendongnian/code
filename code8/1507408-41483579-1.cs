    <CheckBox x:Name="ck" Content="{Binding Caption}" />
----------
    ViewModel vm = new ViewModel();
    ck.DataContext = vm;
    ck.SetBinding(CheckBox.IsCheckedProperty, new Binding(vm.PropertyName) { Source = vm.Source });
