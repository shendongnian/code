    Size A4Size = new Size(793.92, 1122.24);
    Size InfiniteSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
    var pages = new List<FrameworkElement>();
    int pageNumber = 0;
    var printDate = DateTime.Now;
    var size = A4Size;
    var currentPage = new Report(size, printDate);
    currentPage.Render();
    var listElements = new Queue<ElementsToPrint>(...);
    var dummyRenderer = new Viewbox();
    dummyRenderer.Child = currentPage;
    dummyRenderer.Measure(InfiniteSize);
    dummyRenderer.Arrange(new Rect(dummyRenderer.DesiredSize));
    dummyRenderer.UpdateLayout();
    var template = (DataTemplate)View.FindResource("ItemTemplate");
    dummyRenderer.Child = null;
    var availableHeight = currentPage.View.ActualHeight;
    while (listElements.Count > 0)
    {
        var elementToRender = listElements.Dequeue();
        dummyRenderer.Child = new ListViewItem()
        {
           Content = elementToRender,
           ContentTemplate = template,
           Foreground = Brushes.Black
        };
        dummyRenderer.Measure(InfiniteSize);
        dummyRenderer.Arrange(new Rect(dummyRenderer.DesiredSize));
        dummyRenderer.UpdateLayout();
        var renderedItem = (ListViewItem)dummyRenderer.Child;
        dummyRenderer.Child = null;
        var willItFit = availableHeight > renderedItem.ActualHeight;
        if (willItFit)
        {
            currentPage.DataListView.Items.Add(renderedItem);
            availableHeight -= renderedItem.ActualHeight;
        }
        else
        {
            dummyRenderer.Child = currentPage;
            dummyRenderer.Measure(InfiniteSize);
            dummyRenderer.Arrange(new Rect(dummyRenderer.DesiredSize));
            dummyRenderer.UpdateLayout();
            dummyRenderer.Child = null;
            pages.Add(currentPage);
            // Set up a new Page
            pageNumber++;
            currentPage = new DiaryReport(size,pageNumber,printDate,anonymous);
            dummyRenderer.Child = currentPage;
            dummyRenderer.Measure(InfiniteSize);
            dummyRenderer.Arrange(new Rect(dummyRenderer.DesiredSize));
            dummyRenderer.UpdateLayout();
            dummyRenderer.Child = null;
            availableHeight = currentPage.DataListView.ActualHeight;
            currentPage.DataListView.Items.Add(renderedItem);
            availableHeight -= renderedItem.ActualHeight;
        }
