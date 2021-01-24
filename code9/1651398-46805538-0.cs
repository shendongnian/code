    public class MainUCViewModel : ViewModelBase
    {
        private Action<object> btnACommand;
        private Action<object> btnBCommand;
        private Action<object> btnCCommand;
        private object ccVM;
        public object CCVM
        {
            get { return this.ccVM; }
            set
            {
                this.ccVM = value;
                OnPropertyChanged(); // Notify View
            }
        }
        public MainUCViewModel()
        {
        }
        public RelayCommand BtnACommand
        {
            get { return new RelayCommand(btnACommand); }
        }
        public RelayCommand BtnBCommand
        {
            get { return new RelayCommand(btnACommand); }
        }
        public RelayCommand BtnCCommand
        {
            get { return new RelayCommand(btnACommand); }
        }
        public void SetBtnACommand(Action<object> action)
        {
            this.btnACommand = action;
        }
        public void SetBtnBCommand(Action<object> action)
        {
            this.btnBCommand = action;
        }
        public void SetBtnCCommand(Action<object> action)
        {
            this.btnCCommand = action;
        }
    } 
