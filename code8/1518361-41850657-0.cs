    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            LoadCommand = new RelayCommand(async ol => await OnLoadAsync(), CanLoad);
        }
   
        public ICommand LoadCommand { get; }
        private async void OnLoadAync()
        {
            await SomethingAwaitable();
        }
        private Task<bool> SomethingAwaitable()
        {
            //Your code
        }
    }
