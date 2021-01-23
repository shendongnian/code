        private void ListBox_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = sender as ListBoxItem;
            CalcFile clickedCalcFile = lbi.DataContext as CalcFile;
            if(clickedCalcFile != null)
            {
                var viewModel = DataContext as YourViewModelType;
                viewModel.OpenOnDoubleClick(clickedCalcFile);
            }
        }
