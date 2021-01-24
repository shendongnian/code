    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var cb = (ComboBox)sender;
        var item = cb.SelectedItem as SelectMethodCallItem;
        //  This event is raised when user alters the text, but 
        //  SelectedItem will be null in that case. 
        if (item != null && item.HasSelection)
        {
            var edit = (TextBox)cb.Template.FindName("PART_EditableTextBox", cb);
            Action setsel = () =>
            {
                edit.SelectionStart = item.SelStart;
                edit.SelectionLength = item.SelLEngth;
            };
            App.Current.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.ApplicationIdle, setsel);
        }
    }
