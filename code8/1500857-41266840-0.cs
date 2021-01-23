        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject src = VisualTreeHelper.GetParent((DependencyObject)e.OriginalSource);
            if (src.GetType() == typeof(ContentPresenter))
            {
              --- your event code ----
            }
        }
