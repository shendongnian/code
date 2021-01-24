    private void OnClick(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
        Panel panel = btn.Parent as Panel;
        TextBox tbx = panel.Children[0] as TextBox;
        string s = tbx.Text;
        ComboBox cmb = panel.Children[1] as ComboBox;
        object item = cmb.SelectedItem;
    }
