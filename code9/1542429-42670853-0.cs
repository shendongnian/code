    public class CustomComboBox : ComboBox
    {
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Up));
            }
            else if (e.Key == Key.Right)
            {
                this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Right));
            }
            else if (e.Key == Key.Down)
            {
                this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
            }
            else if (e.Key == Key.Left)
            {
                this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
            }
            else
            {
                base.OnPreviewKeyDown(e);
            }
        }
    }
----------
    ComboBox cb = new CustomComboBox();
    Grid.SetRow(cb, row);
    Grid.SetColumn(cb, col);
    cb.IsEditable = true;
    cb.DataContext = myDataContext;
    cb.ItemsSource = myDataItems;
    cb.FocusVisualStyle = null;
    cb.Resources.Add(SystemParameters.VerticalScrollBarWidthKey, 0.0);
    myGrid.Children.Add(cb);
