    private static void DependencyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        UserControl1 uc = (UserControl1)dependencyObject;
        UserControl1ViewModel vm = (UserControl1ViewModel)uc.textBlock1.DataContext;
        vm.PropUserControlViewModel = (string)dependencyPropertyChangedEventArgs.NewValue;
    }
