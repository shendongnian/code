    private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (tabControl.SelectedItem == tab1)
        {
            tabControl.Dispatcher.BeginInvoke(new Action(() =>
            {
                ListBox lb = FindVisualChild<ListBox>(tabControl);
                MessageBox.Show(lb.Items.Count.ToString());
            }));
        }
    }
