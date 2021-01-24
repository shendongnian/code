    private void Button_Click(object sender, RoutedEventArgs e)
    {
        bvnQuery bv = new bvnQuery();
        bool? val = bv.ShowDialog();
        if (val.HasValue && val.Value)
        {
            //...
        }
    }
