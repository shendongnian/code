    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        Nullable<bool> result = dlg.ShowDialog();
        if (result == true)
        {
            string path = System.IO.Path.GetFullPath(dlg.FileName);
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(path);
            DataView dataView = new DataView(dataSet.Tables[0]);
            dataGrid.ItemsSource = dataView;
        }
    }
