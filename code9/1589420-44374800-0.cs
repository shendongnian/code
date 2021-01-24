    if (!System.Windows.Application.Current.Windows.OfType<ButtonListView>().Any())
    {
        ButtonListViewModel buttonListViewModel = new ButtonListViewModel();
        ButtonListView winconfigRole = new ButtonListView();
        winconfigRole.DataContext = buttonListViewModel;
        winconfigRole.Owner = System.Windows.Application.Current.Windows.OfType<ConfigRole>().FirstOrDefault(); //<--
        winconfigRole.Show();
        winconfigRole.Topmost = true;
        winconfigRole.Focus();
    }
