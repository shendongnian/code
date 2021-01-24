     private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = FindScrollViewer(flowDocumentScrollViewer);
            scrollViewer.ScrollToBottom();
        }
        public static ScrollViewer FindScrollViewer(FlowDocumentScrollViewer flowDocumentScrollViewer)
        {
            if (VisualTreeHelper.GetChildrenCount(flowDocumentScrollViewer) == 0)
            {
                return null;
            }
            // Border is the first child of first child of a ScrolldocumentViewer
            DependencyObject firstChild = VisualTreeHelper.GetChild(flowDocumentScrollViewer, 0);
            if (firstChild == null)
            {
                return null;
            }
            Decorator border = VisualTreeHelper.GetChild(firstChild, 0) as Decorator;
            if (border == null)
            {
                return null;
            }
            return border.Child as ScrollViewer;
        }
