    public class MyViewModel : BindableBase
    {
        private int _myproperty1;
        public int myproperty1
        {
            get { return _myproperty1; }
            set { _myproperty1 = value; RaisePropertyChanged(); }
        }
        private int _myproperty2;
        public int myproperty2
        {
            get { return _myproperty2; }
            set { _myproperty2 = value; RaisePropertyChanged(); }
        }
        public DelegateCommand MyCommand { get; set; }
        public MyViewModel()
        {
            MyCommand = new DelegateCommand(MyCommandMethod, CanExecuteMyCommandMethod);
            MyCommand.ObservesProperty((() => myproperty1));
            MyCommand.ObservesProperty((() => myproperty2));
        }
        private bool CanExecuteMyCommandMethod()
        {
            return true;
        }
        private void MyCommandMethod()
        {
        }
    }
