    private void cbxCombobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        using (SQL.DBDataContext dbs = new SQL.DBDataContext())
        {
            string value = cbxCombobox1.SelectedItem as string;
            if (!string.IsNullOrEmpty(value))
            {
                var allCombobox2s = (from t in dbs.View1
                                     where t.Name != null && t.Name.Contains(value)
                                     select t.Name).Distinct().ToList();
                cbxCombobox2.ItemsSource = allCombobox2s;
            }
        }
    }
