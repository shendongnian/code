    public class MainPageViewModel : ViewModelBase
    {   
        //stores value of checkbox  
        private bool _BoxCheckBool;
        //Updates value of _BoxCheckBool
        public bool BoxCheckBool
        {
            set
            {
                Set(ref _BoxCheckBool, value);
                // Assumes your ViewModelBase have method to raising this
                RaisePropertyChanged("BoxCheckString");
            }           
        }
        private string _BoxCheckString;
        public string BoxCheckString
        {
            //logic that determines what will be sent to the textblock
            get
            {
                if (_BoxCheckBool == true)
                {
                    _BoxCheckString = "The Box has been checked";
                }
                else
                {
                    _BoxCheckString = "The Box has not been checked";
                }
                // Boolean type have only two value (true/false) 
                // - you don't need checking for "errors"
                return _BoxCheckString;
            }
            set
            {
                Set(ref _BoxCheckString, value);
            }
        }
    }
