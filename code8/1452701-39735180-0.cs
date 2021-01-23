    public static void PrintTest1(Viewbox viewboxInWindowForRender)
    {
        FrameworkElement[] testContArr = PrepareTestContents();
        //=========================
        PrintManager man = new PrintManager();
        // Show print dialog (or select default printer)
        if (!man.SelectPrinter())
            return;
        man.SetPageMargins(new Thickness(PrintManager.Size1cm * 2));
        //=========================
        List<FrameworkElement> pagesForPrint = new List<FrameworkElement>();
        for (int i = 0; i < testContArr.Length; i++)
        {
            // Put the page content into the control of the size of paper
            FrameworkElement whitePage = man.CreatePageWithContentStretched(testContArr[i]);
            // Temporary put the page into window (need for UpdateLayout)
            viewboxInWindowForRender.Child = whitePage;
            // Update and render whitePage.
            // Measure and Arrange will be used properly.
            viewboxInWindowForRender.UpdateLayout();
            pagesForPrint.Add(whitePage);
        }
        viewboxInWindowForRender.Child = null;
        //=========================
        // Now you can show print preview to user.
        // pagesForPrint has all pages.
        // ...
        //=========================
        MyDocumentPaginator paginator = man.CreatePaginator();
        paginator.AddPages(pagesForPrint);
        // Start printing
        man.Print(paginator, "Printing Test");
    }
    // For testing
    public static FrameworkElement[] PrepareTestContents()
    {
        StackPanel sp1 = new StackPanel();
        sp1.Width = PrintManager.PageSizeA4.Width - PrintManager.Size1cm * 2;
        sp1.Children.Add(PrepareTestBorder("Alice has a cat."));
        sp1.Children.Add(PrepareTestBorder("Page number one."));
        StackPanel sp2 = new StackPanel();
        sp2.Width = sp1.Width / 2;
        sp2.Children.Add(PrepareTestBorder("Farmer has a dog."));
        sp2.Children.Add(PrepareTestBorder("Page number two."));
        return new FrameworkElement[] {sp1, sp2 };
    }
    // For testing
    public static FrameworkElement PrepareTestBorder(string text)
    {
        Border b = new Border();
        b.BorderBrush = Brushes.Black;
        b.BorderThickness = new Thickness(1);
        b.Margin = new Thickness(0, 0, 0, 5);
        TextBlock t = new TextBlock();
        t.Text = text;
        b.Child = t;
        return b;
    }
