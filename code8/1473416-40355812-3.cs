    public static class Extensions
    {
        public static IEnumerable<UIElement> ChildrenBreadthFirst(this UIElement element)
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
    }
