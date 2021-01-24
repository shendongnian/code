    public static class TreeHelper
        {
            public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject
            {
                if (depObj == null) yield break;
    
                for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
                    var children = child as T;
                    if (children != null)
                        yield return children;
    
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
