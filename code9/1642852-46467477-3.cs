    private async void appbar_Printer_Click(object sender, RoutedEventArgs e)
    {
        if (printDoc != null)
        {
            printDoc.GetPreviewPage -= OnGetPreviewPage;
            printDoc.Paginate -= PrintDic_Paginate;
            printDoc.AddPages -= PrintDic_AddPages;
        }
        this.printDoc = new PrintDocument();
        printDoc.GetPreviewPage += OnGetPreviewPage;
        printDoc.Paginate += PrintDic_Paginate;
        printDoc.AddPages += PrintDic_AddPages;
        bool showPrint = await PrintManager.ShowPrintUIAsync();
    }
    private void PrintDic_AddPages(object sender, AddPagesEventArgs e)
    {
        Rectangle page = (Rectangle)this.FindName("MyWebViewRectangle");
        printDoc.AddPage(page);
        printDoc.AddPagesComplete();
    }
    private void PrintDic_Paginate(object sender, PaginateEventArgs e)
    {
        PrintTaskOptions opt = task.Options;
        PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(e.PrintTaskOptions);
    
        printDoc.SetPreviewPageCount(1, PreviewPageCountType.Final);
    }
