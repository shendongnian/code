    public class BaseViewModel : ObservableObject
    {
        private MainViewModel _mainVM;
    
        public BaseViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }
    
        protected void Navigate<T>() where T : BaseViewModel
        {
            //Create new instance of generic type(i.e. Type of view model passed)
            T newVM = (T)Activator.CreateInstance(typeof(T), _mainVM);
            //Change MainViewModels ViewModel to the new instance
            _mainVM.Navigate<T>(newVM);
        }
    }
