     public MainPageViewModel(IUnityContainer container, IDataService dataService)
     {
         ... 
         var Tenders = new IncrementalLoadingCollection<MainPageViewModel, Tender>(this, 10);
     }
