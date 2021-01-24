    public class MyClass : INotifyPropertyChanged
    {
      public NotifyTask<ObservableCollection<CProyecto>> Prope { get; private set; }
      public MyClass()
      {
        // Synchronously *start* the operation.
        Prope = NotifyTask.Create(LoadDataAsync());
      }
      async private Task<ObservableCollection<CProyecto>> LoadDataAsync()
      {
        return await clsStaticClassDataLoader.GetDataFromWebService();
      }
    }
