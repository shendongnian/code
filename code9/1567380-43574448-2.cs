    public class BlueViewModel : BaseViewModel
    {
        //Relay command to call 'ToRed' function
        public ICommand ChangeToRed
        {
            get { return new RelayCommand(ToRed); }
        }
    
        //Requires MainViewModel for BaseViewModel
        public BlueViewModel(MainViewModel main) : base(main)
        {
    
        }
    
        //Calling BaseViewModel function. Passed BaseViewModel Type
        public void ToRed(object param)
        {
            Navigate<RedViewModel>();
        }
    }
