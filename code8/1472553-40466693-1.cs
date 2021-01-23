    private void DocumentTemplatesGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space || e.Key == System.Windows.Input.Key.Enter)
            {
                if (e.Source is DataGrid)
                {
                    string navigationUri = ((e.Source as DataGrid).SelectedItem as Class).Name;
                    Process.Start(navigationUri);
                }
                e.Handled = true;
            }
        }
