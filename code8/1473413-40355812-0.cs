    private static IEnumerable<UIElement> ChildrenDepthFirst(UIElement element)
    {
        var count = VisualTreeHelper.GetChildrenCount(element);
        for (var i = 0; i < count; i++)
        {
            var child = (UIElement)VisualTreeHelper.GetChild(element, i);
            yield return child;
            foreach (var lowerChild in ChildrenDepthFirst(child))
            {
                yield return lowerChild;
            }
        }
    }
    private void GridView_Loaded(object sender, RoutedEventArgs e)
    {
        var scrollViewer = ChildrenDepthFirst((UIElement)sender).OfType<ScrollViewer>().First();
    }
