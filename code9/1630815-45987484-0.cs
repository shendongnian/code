    public class MyViewModel : ReactiveObject, ISupportsActivation
    {
        public MyViewModel()
        {
            this.WhenActivated(d => LoadDataAsync().ToObservable().Subscribe(
                    res => { }, 
                    exc => 
                    {
                        Debug.WriteLine("Error ocurred on InitAsync: " + exc.Message + " - " + exc.StackTrace);
                        //HANDLE EXCEPTION
                    }
                    ).DisposeWith(d));
        }
    
        private async Task LoadDataAsync() => await DataBase.LoadData();
    
        // Add this property to implement the interface
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
