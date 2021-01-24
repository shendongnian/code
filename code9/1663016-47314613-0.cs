    private void ListClickListener(object sender, MouseButtonEventArgs e)
    {
        var vm = (MyListBoxItemClass)((FrameworkElement)sender).DataContext;
        MessageBox.Show("FullName is " + vm.FullName);
    }
