    public class MyFirstPage : ContentPage
    {
      public MyFirstPage()
      {
        this.BindingContext = new MyFirstPageViewModel();
      }
    }
    
    public class MyFirstPageViewModel : INotifyPorpertyChanged
    {
      public ICommand<List<string>> DownloadDataCmd { get; }
      
      public MyFirstPageViewModel()
      {
        DownloadDataCmd = new Command<List<string>>(async () => {
            var data = await dataService.DownloadData();
            await navService.PushAsync(new MySecondPage(data));
        });
      }
    }
    
    public class MySecondPage : ContentPage
    {
      public MySecondPage(List<string> downloadedData)
      {
        this.BindingContext = new MySecondPageViewModel(downloadedData);
      }
    }
    
    public class MySecondPageViewModel : INotifyPropertyChanged
    {
      public MySecondPageViewModel(List<string> downloadedData)
      {
         // Do whatever is needed with the data
      }
    }
