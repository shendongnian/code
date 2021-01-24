    private void SyncScrollViewers()
    {
        var scrollViewer1 = MyListView1.GetScrollViewer();
        var scrollViewer2 = MyListView2.GetScrollViewer();
    
        scrollViewer1.ViewChanged += (s, e) =>
        {
            scrollViewer2.ChangeView(null, scrollViewer1.VerticalOffset, null, false);
        };
    }
