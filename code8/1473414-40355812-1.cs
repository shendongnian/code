    private static IEnumerable<UIElement> ChildrenBreadthFirst(UIElement element)
    {
        var queue = new Queue<UIElement>();
        queue.Enqueue(element);
        while (queue.Count > 0)
        {
            element = queue.Dequeue();
            var count = VisualTreeHelper.GetChildrenCount(element);
            for (var i = 0; i < count; i++)
            {
                var child = (UIElement)VisualTreeHelper.GetChild(element, i);
                yield return child;
                queue.Enqueue(child);
            }
        }
    }
    private void GridView_Loaded(object sender, RoutedEventArgs e)
    {
        var scrollViewer = ChildrenBreadthFirst((UIElement)sender)
                               .OfType<ScrollViewer>()
                               .First();
    }
