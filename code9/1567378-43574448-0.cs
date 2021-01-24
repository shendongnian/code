    public class MainViewModel : ObservableObject //ObservableObject being a property change notification parent
    {
        //Current view will always be here
        public BaseViewModel ViewModel { get; set; }
    
        public MainViewModel()
        {
            //By default we will say this is out startup view
            Navigate<RedViewModel>(new RedViewModel(this));
        }
    
        public void Navigate<T>(BaseViewModel viewModel) where T : BaseViewModel
        {
            ViewModel = viewModel as T;
            Console.WriteLine(ViewModel.GetType());
            OnPropertyChanged("ViewModel");
        }
    }
