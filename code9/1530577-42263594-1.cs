    public class ModelView
    {
        public ModelView()
        {
            _models = new ObservableCollection<Model>(); 
            _pCommand = new Command(DoParameterisedCommand);
        }
        ObservableCollection<Model> _models;
        public ObservableCollection<Model> Models { get { return _models; } }
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
    }
