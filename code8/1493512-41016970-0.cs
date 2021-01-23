        public static List<T> GetChildrenOfType<T>(this DependencyObject depObj)
        where T : DependencyObject
        {
            var result = new List<T>();
            if (depObj == null) return null;
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(depObj);
            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();
                var childrenCount = VisualTreeHelper.GetChildrenCount(currentElement);
                for (var i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(currentElement, i);
                    if (child is T)
                        result.Add(child as T);
                    queue.Enqueue(child);
                }
            }
            return result;
        }
