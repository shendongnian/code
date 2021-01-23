    private void RefreshPlayers(object sender, RoutedEventArgs e)
        {            
            if(myGrid.DataContext != null)
            {
                var viewModel = myGrid.DataContext as LastRefreshedViewModel;
                if(viewModel != null)
                {
                    viewModel.Reset();
                }
            }
        }
