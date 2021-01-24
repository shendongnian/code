    public class MainViewMode : IMainViewCallbacks
    {
       private vm = null;
       public MainWindow()
       {
          vm = new MainViewModel(this);
          this.DataContext = vm;
       }
    }
