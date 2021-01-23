    private void MyScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e) 
    {
        if (!conditionals) return;
        
        if (e.IsIntermediate) 
        {
            var uiElement = MyScrollViewer.Content as UIElement;
            uiElement?.CancelDirectManipulations();
        }
    
        ScrollTo(location);
    }
    private void Temporary_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        if (e.IsIntermediate) return;
        MyScrollViewer.ViewChanged -= Temporary_ViewChanged;
        MyScrollViewer.ViewChanged -= MyScrollViewer_ViewChanged;
        MyScrollViewer.ViewChanged += MyScrollViewer_ViewChanged;
        MyScrollViewer.HorizontalScrollMode = ScrollMode.Enabled;
        MyScrollViewer.VerticalScrollMode = ScrollMode.Enabled;
        MyScrollViewer.ZoomMode = ZoomMode.Enabled;
    }
    private void ScrollTo(double offset)
    {
        MyScrollViewer.ViewChanged -= MyScrollViewer_ViewChanged;
        MyScrollViewer.ViewChanged -= Temporary_ViewChanged;
        MyScrollViewer.ViewChanged += Temporary_ViewChanged;
        MyScrollViewer.HorizontalScrollMode = ScrollMode.Disabled;
        MyScrollViewer.VerticalScrollMode = ScrollMode.Disabled;
        MyScrollViewer.ZoomMode = ZoomMode.Disabled;
        MyScrollViewer.ChangeView(offset, null, null);
    }
