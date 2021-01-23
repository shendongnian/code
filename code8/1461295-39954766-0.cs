    public static IEnumerable<T> EnumVisualOfType<T>(Visual visual) where T : Visual
    {
        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
        {
            var visualChild = (Visual)VisualTreeHelper.GetChild(visual, i);
            foreach (var child in EnumVisualOfType<T>(visualChild))
                yield return child;
            var childVisual = visualChild as T;
            if (childVisual != null)
                yield return childVisual;
        }
    }
