    private void DoDragandDrop(ListViewItem item, DataObject obj, DragDropEffects effect)
            {
                if ((item != null) && (obj != null))
                {
                    DragDrop.DoDragDrop(item, obj, effect);
                }
            }
    
     private void GlobalHandler(object sender, InputEventArgs e)
            {
                Point? startPoint;
                if (object.ReferenceEquals(e.RoutedEvent, UIElement.PreviewMouseLeftButtonDownEvent))
                {
                    MouseButtonEventArgs args = e as MouseButtonEventArgs;
                    ListViewItem item = VisualTreeHelperUtils.FindParent<ListViewItem>((DependencyObject) args.OriginalSource);
                    if (item != null)
                    {
                        DNA2RunInfoDisplay content = item.Content as DNA2RunInfoDisplay;
                        if ((content != null) && (content.PlateIndex == -2147483648))
                        {
                            return;
                        }
                        this.SelectedDragItem = item;
                        this.StartPoint = new Point?(args.GetPosition(null));
                    }
                }
                if (object.ReferenceEquals(e.RoutedEvent, UIElement.PreviewTouchDownEvent))
                {
                    ListView listView = sender as ListView;
                    TouchEventArgs args2 = e as TouchEventArgs;
                    object selectedItem = this.RunSetupListView.SelectedItem;
                    ListViewItem itemToDrag = VisualTreeHelperUtils.FindParent<ListViewItem>((DependencyObject) args2.OriginalSource);
                    if (itemToDrag != null)
                    {
                        itemToDrag.Focus();
                        this.SelectedDragItem = itemToDrag;
                        this.StartPoint = new Point?(args2.GetTouchPoint(null).Position);
                        this.m_AdornerLayer = this.InitializeAdornerLayer(itemToDrag, listView);
                        this.UpdateDragAdornerLocation(args2.GetTouchPoint(listView).Position);
                        if (this.SelectedDragItem.Content != BindingOperations.DisconnectedSource)
                        {
                            this.dataObject = new DataObject(this.SelectedDragItem.Content as DNA2RunInfoDisplay);
                        }
                        listView.CaptureTouch(args2.TouchDevice);
                    }
                }
                if (object.ReferenceEquals(e.RoutedEvent, UIElement.PreviewMouseLeftButtonUpEvent))
                {
                    startPoint = null;
                    this.StartPoint = startPoint;
                    this.SelectedDragItem = null;
                }
                if (object.ReferenceEquals(e.RoutedEvent, UIElement.PreviewTouchUpEvent))
                {
                    startPoint = null;
                    this.StartPoint = startPoint;
                    this.SelectedDragItem = null;
                    this.dataObject = null;
                    if (this.m_DragAdorner != null)
                    {
                        this.m_DragAdorner.Visibility = Visibility.Collapsed;
                    }
                }
                if (object.ReferenceEquals(e.RoutedEvent, UIElement.PreviewMouseMoveEvent))
                {
                    MouseEventArgs args3 = e as MouseEventArgs;
                    if (!(sender is ListView))
                    {
                        return;
                    }
                    if ((args3.LeftButton == MouseButtonState.Pressed) && ((this.StartPoint != null) && (this.SelectedDragItem != null)))
                    {
                        Point position = args3.GetPosition(null);
                        startPoint = this.StartPoint;
                        Vector vector = startPoint.Value - position;
                        if (((Math.Abs(vector.get_X()) > SystemParameters.MinimumHorizontalDragDistance) || (Math.Abs(vector.get_Y()) > SystemParameters.MinimumVerticalDragDistance)) && !this._inDragMode)
                        {
                            ListView listView = sender as ListView;
                            ListViewItem selectedDragItem = this.SelectedDragItem;
                            if (selectedDragItem == null)
                            {
                                return;
                            }
                            this.m_AdornerLayer = this.InitializeAdornerLayer(selectedDragItem, listView);
                            this.UpdateDragAdornerLocation(args3.GetPosition(listView));
                            this.mousePoint = position;
                            this._inDragMode = true;
                            listView.CaptureMouse();
                            DragDrop.DoDragDrop(selectedDragItem, new DataObject(selectedDragItem.Content as DNA2RunInfoDisplay), DragDropEffects.Move);
                            listView.ReleaseMouseCapture();
                            this._inDragMode = false;
                            startPoint = null;
                            this.StartPoint = startPoint;
                            this.SelectedDragItem = null;
                        }
                    }
                }
                if (object.ReferenceEquals(e.RoutedEvent, UIElement.PreviewTouchMoveEvent))
                {
                    Point position = (e as TouchEventArgs).GetTouchPoint(null).Position;
                    startPoint = this.StartPoint;
                    if ((startPoint == null) || (this.SelectedDragItem == null))
                    {
                        if (this.m_DragAdorner != null)
                        {
                            this.m_DragAdorner.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        startPoint = this.StartPoint;
                        Point point3 = position;
                        if ((startPoint != null) ? ((startPoint != null) ? (startPoint.GetValueOrDefault() != point3) : false) : true)
                        {
                            startPoint = this.StartPoint;
                            Vector vector2 = startPoint.Value - position;
                            if (((Math.Abs(vector2.get_X()) > SystemParameters.MinimumHorizontalDragDistance) || (Math.Abs(vector2.get_Y()) > SystemParameters.MinimumVerticalDragDistance)) && (this.dataObject != null))
                            {
                                this.DoDragandDrop(this.SelectedDragItem, this.dataObject, DragDropEffects.Move);
                            }
                        }
                    }
                    this.SelectedDragItem = null;
                    startPoint = null;
                    this.StartPoint = startPoint;
                }
            }
    
            private void HandleDragEvent(object sender, DragEventArgs e)
            {
                if (!e.Data.GetDataPresent(typeof(DNA2RunInfoDisplay)))
                {
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
                }
                else
                {
                    DependencyObject originalSource = e.OriginalSource as DependencyObject;
                    if (originalSource == null)
                    {
                        e.Effects = DragDropEffects.None;
                        e.Handled = true;
                    }
                    else
                    {
                        ListViewItem item = VisualTreeHelperUtils.FindParent<ListViewItem>(originalSource);
                        if (item == null)
                        {
                            e.Effects = DragDropEffects.None;
                            e.Handled = true;
                        }
                        else
                        {
                            if ((item.Content as DNA2RunInfoDisplay).RunState == DNA2RunStates.Unassigned)
                            {
                                e.Effects = DragDropEffects.None;
                            }
                            else
                            {
                                ListView relativeTo = sender as ListView;
                                if (relativeTo != null)
                                {
                                    Point point = item.TransformToAncestor((Visual) relativeTo).Transform(new Point(0.0, 0.0));
                                    this.UpdateDragAdornerLocation(new Point(point.get_X(), e.GetPosition(relativeTo).get_Y()));
                                    this.m_DragAdorner.Visibility = Visibility.Visible;
                                }
                                e.Effects = e.AllowedEffects;
                            }
                            e.Handled = true;
                        }
                    }
                }
            }
     private AdornerLayer InitializeAdornerLayer(ListViewItem itemToDrag, ListView listView)
            {
                VisualBrush brush = new VisualBrush(itemToDrag);
                this.m_DragAdorner = new BRDragAdornerWithVisualBrush(listView, itemToDrag.RenderSize, brush);
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(listView);
                adornerLayer.Add(this.m_DragAdorner);
                return adornerLayer;
            }
    
     private void RunSetupListView_DragEnter(object sender, DragEventArgs e)
            {
                this.HandleDragEvent(sender, e);
            }
    
            private void RunSetupListView_DragLeave(object sender, DragEventArgs e)
            {
                if (this.m_DragAdorner != null)
                {
                    this.m_DragAdorner.Visibility = Visibility.Collapsed;
                }
            }
    
            private void RunSetupListView_DragOver(object sender, DragEventArgs e)
            {
                FrameworkElement depObj = sender as FrameworkElement;
                if (depObj != null)
                {
                    ScrollViewer firstVisualChild = VisualTreeHelperUtils.GetFirstVisualChild<ScrollViewer>(depObj);
                    if (firstVisualChild != null)
                    {
                        double num = e.GetPosition(depObj).get_Y();
                        if (num < 30.0)
                        {
                            firstVisualChild.ScrollToVerticalOffset(firstVisualChild.VerticalOffset - 20.0);
                        }
                        else if (num > (depObj.ActualHeight - 30.0))
                        {
                            firstVisualChild.ScrollToVerticalOffset(firstVisualChild.VerticalOffset + 20.0);
                        }
                        this.HandleDragEvent(sender, e);
                    }
                }
            }
    
            private void RunSetupListView_Drop(object sender, DragEventArgs e)
            {
                try
                {
                    this._inDragMode = false;
                    if (e.Data.GetDataPresent(typeof(DNA2RunInfoDisplay)))
                    {
                        DNA2RunInfoDisplay data = (DNA2RunInfoDisplay) e.Data.GetData(typeof(DNA2RunInfoDisplay));
                        ListViewItem item = VisualTreeHelperUtils.FindParent<ListViewItem>((DependencyObject) e.OriginalSource);
                        if (item != null)
                        {
                            this.DNA2RunSetupVM.ChangeRunPriority(data, item.Content as DNA2RunInfoDisplay);
                            this.PropertyChanged(this, new PropertyChangedEventArgs("RunSetupInfoList"));
                        }
                    }
                }
                finally
                {
                    if (this.m_DragAdorner != null)
                    {
                        this.m_DragAdorner.Visibility = Visibility.Collapsed;
                    }
                }
            }
