        private void Common_Drop(object sender, DragEventArgs e)
        {
            var destLisBox = sender as ListBox;
            var dragDropData = e.Data.GetData(typeof(DragDropData)) as DragDropData;
            if (dragDropData != null)
            {
                var dataWhereToInsert = GetDataFromListBox(destLisBox, e.GetPosition(destLisBox));
                if (dataWhereToInsert != null)
                {
                    var insertAtIndex = destLisBox.Items.IndexOf(dataWhereToInsert);
                    if (insertAtIndex >= 0)
                    {
                        dragDropData.DragStartSource.Items.Remove(dragDropData.ActualData);
                        destLisBox.Items.Insert(insertAtIndex, dragDropData.ActualData);
                    }
                }
                else
                {
                    dragDropData.DragStartSource.Items.Remove(dragDropData.ActualData);
                    destLisBox.Items.Add(dragDropData.ActualData);
                }
            }
        }   
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }
        private void Common_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var srcListBox = sender as ListBox;
            if (srcListBox != null)
            {
                var data = GetDataFromListBox(srcListBox, e.GetPosition(srcListBox));
                if (data != null)
                {
                    var dragDropData = new DragDropData
                    {
                        ActualData = data,
                        DragStartSource = srcListBox
                    };
                    DragDrop.DoDragDrop(srcListBox, dragDropData, DragDropEffects.Move);
                }
            }
        }
