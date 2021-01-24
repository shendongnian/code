    private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Dispatcher.BeginInvoke(new Action(() => TabItem_UpdateHandler()));
    }
    void TabItem_UpdateHandler()
    {
        ContentPresenter myContentPresenter = tabControl1.Template.FindName("PART_SelectedContentHost", tabControl1) as ContentPresenter;
        if (myContentPresenter.ContentTemplate == tab1.ContentTemplate)
        {
            myContentPresenter.ApplyTemplate();
            var lb1 = myContentPresenter.ContentTemplate.FindName("listBox", myContentPresenter) as ListBox;
        }
    }
