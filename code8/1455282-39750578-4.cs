    protected void RunCommandButton_Click(object sender, RoutedEventArgs args)
    {
        var vm = (MyVM)DataContext;
        var selectedThing = lb.SelectedItem as MyThing;
        if (selectedThing != null)
        {
            vm.RunMe(selectedThing);
        }
    }
