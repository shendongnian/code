        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            MenuModel pModel = new MenuModel();
            MenuViewModel pViewModel = new MenuViewModel(pModel);
            MenuView pView = new MenuView();
            pView.DataContext = pViewModel;
            MainWindowFrame.Content = pView;
        }
