    public class KDataGrid : System.Windows.Controls.DataGrid
    {
        public KDataGrid()
        {
            Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var scroll = FindVisualChild<ScrollViewer>();
            if (scroll != null)
            {
                scroll.MouseDown += (o, args) =>
                {
                    if (IsKeyboardFocusWithin)
                        return;
                    Focus();
                };
            }
        }
        public static T FindVisualChild<T>(this DependencyObject root) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(root, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = child.FindVisualChild<T>();
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
