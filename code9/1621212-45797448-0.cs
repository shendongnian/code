    void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.OriginalSource is ComboBox)
        {
            Dispatcher.BeginInvoke(new Action(() =>
                {
                    dg1.Columns[0].Width = new DataGridLength();
                    dg1.UpdateLayout();
                    dg1.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                }));
        }
    }
