     scrollViewer.PreviewMouseWheel += delegate
                {
                    var visibility = scrollViewer.ComputedVerticalScrollBarVisibility;
                    if (visibility == Visibility.Collapsed)
                    {
                        //try to fetch data
                    }
                };
