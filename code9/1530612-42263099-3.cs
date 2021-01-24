    public class ViewModel :INotifyPropertyChanged
    {
        public ViewModel()
        { 
            _pCommand = new Command(DoParameterisedCommand);
            Model m1 = new Model() { Name = "model1" };
            Model m2 = new Model() { Name = "model2" };
            Model m3 = new Model() { Name = "model3" };
            Model m4 = new Model() { Name = "model4", Models = new Model[2] { m1, m2 } };
            Model m5 = new Model() { Name = "model5", Models = new Model[2] { m4, m3 } };
            Model m6 = new Model() { Name = "model6" };
            Model m7 = new Model() { Name = "model7" };
            Model m8 = new Model() { Name = "model8" };
            Model m9 = new Model() { Name = "model9", Models = new Model[2] { m6, m7 } };
            Model m10 = new Model() { Name = "model10", Models = new Model[2] { m8, m9 } };
            _models = new ObservableCollection<Model>(new Collection<Model>() { m1, m2, m3, m4, m5 });
        }
        ObservableCollection<Model> _models;
        public ObservableCollection<Model> Models { get { return _models; } set { _models = value; RaisePropertyChanged("Models"); } }
        
        private void DoParameterisedCommand(object parameter)
        {
            MessageBox.Show("Parameterised Command; Parameter is '" +
                         parameter.ToString() + "'.");
        }
        Command _pCommand;
        public Command PCommand
        {
            get { return _pCommand; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
    public class Model : INotifyPropertyChanged
    {
        Model[] _models;
        public Model[] Models { get { return _models; } set { _models = value; RaisePropertyChanged("Models"); } }
        string _name;
        public string Name { get { return _name; } set { _name = value; RaisePropertyChanged("Name"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
    public class Command : ICommand
    {
        public Command(Action<object> parameterizedAction, bool canExecute = true)
        {
            _parameterizedAction = parameterizedAction;
            _canExecute = canExecute;
        }
        Action<object> _parameterizedAction = null;
        bool _canExecute = false;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler CanExecuteChanged;
        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute;
        }
        void ICommand.Execute(object parameter)
        {
            this.DoExecute(parameter);
        }
        public virtual void DoExecute(object param)
        {
            if (_parameterizedAction != null)
                _parameterizedAction(param);
            else
                throw new Exception();
        }
     }
