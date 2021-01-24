    private Canvas annotationCanvas;
    private void Loaded(object sender, RoutedEventArgs e) {
        ScrollBar scrollBar = GetVisualChild<ScrollBar>(table);
        annotationCanvas = (Canvas)scrollBar.Template.FindName("AnnotationCanvas", scrollBar);
        UpdateAnnotations();
    }
    private static T GetVisualChild<T>(DependencyObject parent) where T : Visual {
        T child = default(T);
        int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < numVisuals; i++) {
            Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
            child = v as T;
            if (child == null) {
                child = GetVisualChild<T>(v);
            }
            if (child != null) {
                break;
            }
        }
        return child;
    }
    // Fill the Canvas with horizontal markers. Can be optimized.
    private void UpdateAnnotations() {
        if (annotationCanvas == null)
            return;
        annotationCanvas.Children.Clear();
        int i = 0;
        double m = items.Count;
        double height = table.ActualHeight;
        foreach (Item item in items) {
            if (item.someCondition) {
                int p = (int)(height * i / m);
                annotationCanvas.Children.Add(new Line() { X1 = 0, Y1 = p, X2 = 30, Y2 = p, StrokeThickness = 1, Stroke = Brushes.Red });
            }
            i++;
        }
    }
