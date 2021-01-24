        public MainPage()
        {
            this.InitializeComponent();
            var scrollViewer = GetDescendants(lvSummaryList).OfType<ScrollViewer>().FirstOrDefault();
            var verticalScrollbar = GetDescendants(scrollViewer).OfType<ScrollBar>()
                .FirstOrDefault(x => x.Orientation == Orientation.Vertical);
            
            verticalScrollbar.SmallChange = 5;
            //You can listen to the Scroll event of the vertical ScrollBar, and to pragmatically adjust the ScrollBar position
            /*verticalScrollbar.Scroll += (o, e) =>
            {
                if (e.ScrollEventType != ScrollEventType.EndScroll)
                    scrollViewer.ScrollToVerticalOffset(100); // Scroll to the top
                if (e.NewValue >= verticalScrollbar.Maximum)
                    scrollViewer.ScrollToVerticalOffset(0); // Scroll to the top
            };*/
        }
        public static IEnumerable<DependencyObject> GetDescendants(DependencyObject start)
        {
            var queue = new Queue<DependencyObject>();
            var count = VisualTreeHelper.GetChildrenCount(start);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(start, i);
                yield return child;
                queue.Enqueue(child);
            }
            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();
                var count2 = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count2; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    yield return child;
                    queue.Enqueue(child);
                }
            }
        }
