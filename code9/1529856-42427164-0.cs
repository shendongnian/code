    private void ckbxSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            DockPanel dp = FindVisualChild<DockPanel>(pdflistView, 0);
            ScrollContentPresenter scp = FindVisualChild<ScrollContentPresenter>(dp, 1);
            VirtualizingStackPanel vsp = FindVisualChild<VirtualizingStackPanel>(scp, 0);
    
            foreach (ListViewItem item in vsp.Children)
            {
                item.IsSelected = (bool)((CheckBox)sender).IsChecked;
            }
        }
    
        private static T FindVisualChild<T>(UIElement element, int childindex) where T : UIElement
        {
            UIElement child = element;
            while (child != null)
            {
                T correctlyTyped = child as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }
    
                child = VisualTreeHelper.GetChild(child, childindex) as UIElement;
            }
            return null;
        }
