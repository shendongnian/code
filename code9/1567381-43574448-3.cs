    public class RedViewModel : BaseViewModel
    {
        //Relay command to call 'ToBlue' function
        public ICommand ChangeToBlue
        {
            get { return new RelayCommand(ToBlue); }
        }
    
        //Requires MainViewModel for BaseViewModel
        public RedViewModel(MainViewModel main) : base(main)
        {
    
        }
    
        //Calling BaseViewModel function. Passed BaseViewModel Type
        public void ToBlue(object param)
        {
            Navigate<BlueViewModel>();
        }
    }
