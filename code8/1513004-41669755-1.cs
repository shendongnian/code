      PrintManager printmgr = PrintManager.GetForCurrentView();        
      PrintDocument printDoc = null;         
      PrintTask task = null; 
      public MainPage()
      {
          this.InitializeComponent(); 
          printmgr.PrintTaskRequested += Printmgr_PrintTaskRequested;
      }
      private void Printmgr_PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
      {  
          var deferral = args.Request.GetDeferral(); 
          task = args.Request.CreatePrintTask("Print", OnPrintTaskSourceRequrested);
          //task.Completed += PrintTask_Completed;
          PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(task.Options);    
          deferral.Complete();
      } 
      //private void PrintTask_Completed(PrintTask sender, PrintTaskCompletedEventArgs args)
      //{
      //    //Completed
      //}
      private async void OnPrintTaskSourceRequrested(PrintTaskSourceRequestedArgs args)
      {
          var def = args.GetDeferral();
          await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            { 
                args.SetSource(printDoc?.DocumentSource);
            });
          def.Complete();
      }
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
          printDoc.AddPage(this);
          printDoc.AddPagesComplete();
      }       
      private void PrintDic_Paginate(object sender, PaginateEventArgs e)
      {
          PrintTaskOptions opt = task.Options;
          PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(e.PrintTaskOptions);
          printDoc.SetPreviewPageCount(1, PreviewPageCountType.Final);
      }
      private void OnGetPreviewPage(object sender, GetPreviewPageEventArgs e)
      {
            printDoc.SetPreviewPage(e.PageNumber, PrintArea); 
      }    
 
