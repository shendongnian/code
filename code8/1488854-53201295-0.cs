    if (hasError)
    {
        e.Cancel = true;
        (sender as DataGrid).Dispatcher.BeginInvoke((Action)(() =>
        {
            (sender as DataGrid).SelectedIndex = e.Row.GetIndex(); //select current row
            ((System.Windows.UIElement)e.EditingElement.Parent).Focus(); //focus current cell
        }));
    }
