    public static class ViewHelper
    {
        public static IEnumerable<DependencyObject> ChildrenBreadthFirst(this DependencyObject obj, bool includeSelf = false)
        {
            if (includeSelf)
            {
                yield return obj;
            }
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(obj);
            while (queue.Count > 0)
            {
                obj = queue.Dequeue();
                var count = VisualTreeHelper.GetChildrenCount(obj);
                for (var i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(obj, i);
                    yield return child;
                    queue.Enqueue(child);
                }
            }
        }
    }
