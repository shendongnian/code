    void button2_Click(object sender, RoutedEventArgs e)
    {
        listView.Items.Add("ABCDEFGHIJKL");
        GridView gv = listView.View as GridView;
        gv.Columns[0].Width = gv.Columns[0].ActualWidth;
        gv.Columns[0].Width = double.NaN;
    }
