    private void tabControl1_Loaded(object sender, RoutedEventArgs e)
    {
        ContentPresenter myContentPresenter = tabControl1.Template.FindName("PART_SelectedContentHost", tabControl1) as ContentPresenter;
        TabItem_UpdateHandler(myContentPresenter);
        DependencyPropertyDescriptor
            .FromProperty(ContentPresenter.ContentTemplateProperty, typeof(ContentPresenter))
            .AddValueChanged(myContentPresenter, TabControl_ContentChanged);
    }
    private void tabControl1_Unloaded(object sender, RoutedEventArgs e)
    {
        ContentPresenter myContentPresenter = tabControl1.Template.FindName("PART_SelectedContentHost", tabControl1) as ContentPresenter;
        DependencyPropertyDescriptor
            .FromProperty(ContentPresenter.ContentTemplateProperty, typeof(ContentPresenter))
            .RemoveValueChanged(myContentPresenter, TabControl_ContentChanged);
    }
    private void TabControl_ContentChanged(object sender, EventArgs e)
    {
        TabItem_UpdateHandler(sender as ContentPresenter);
    }
    void TabItem_UpdateHandler(ContentPresenter myContentPresenter)
    {
        if (myContentPresenter.ContentTemplate == tab1.ContentTemplate)
        {
            myContentPresenter.ApplyTemplate();
            var lb1 = myContentPresenter.ContentTemplate.FindName("listBox", myContentPresenter) as ListBox;
            // check lb1 for null before using it
        }
    }
