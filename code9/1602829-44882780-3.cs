    private void lb_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Tab)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                ContentPresenter cp = sender as ContentPresenter;
                VirtualizingStackPanel sp = FindParent<VirtualizingStackPanel>(cp);
                if (sp != null)
                {
                    int uiIndex = sp.Children.IndexOf(cp);
                    if (uiIndex > -1)
                    {
                        ContentPresenter cpp;
                        while (++uiIndex < sp.Children.Count - 1)
                        {
                            cpp = sp.Children[uiIndex] as ContentPresenter;
                            if (cpp != null)
                            {
                                TextBox textBox = FindChild<TextBox>(cpp);
                                if (textBox != null && textBox.Visibility == Visibility.Visible)
                                    return;
                            }
                        }
                        //no TextBox was found. generate the containers programmatically
                        int sourceIndex = lb.Items.IndexOf(cp.DataContext);
                        if (sourceIndex > -1)
                        {
                            ScrollViewer sv = FindChild<ScrollViewer>(lb);
                            if (sv != null)
                            {
                                while (++sourceIndex < lb.Items.Count - 1)
                                {
                                    cpp = lb.ItemContainerGenerator.ContainerFromIndex(sourceIndex) as ContentPresenter;
                                    while (cpp == null)
                                    {
                                        sv.ScrollToVerticalOffset(sv.VerticalOffset + 1);
                                        lb.UpdateLayout();
                                        cpp = lb.ItemContainerGenerator.ContainerFromIndex(sourceIndex) as ContentPresenter;
                                    }
                                    TextBox textBox = FindChild<TextBox>(cpp);
                                    if (textBox != null && textBox.Visibility == Visibility.Visible)
                                    {
                                        textBox.Focus();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }), System.Windows.Threading.DispatcherPriority.Background);
        }
    }
    private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(dependencyObject);
        if (parent == null) return null;
        var parentT = parent as T;
        return parentT ?? FindParent<T>(parent);
    }
    private static T FindChild<T>(DependencyObject dependencyObject) where T : DependencyObject
    {
        if (dependencyObject == null) return null;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
        {
            var child = VisualTreeHelper.GetChild(dependencyObject, i);
            var result = (child as T) ?? FindChild<T>(child);
            if (result != null) return result;
        }
        return null;
    }
