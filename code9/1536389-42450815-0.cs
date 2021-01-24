    public class ViewModel
    {
        public ViewModel()
    {
                _selectChangeCommand= new RelayCommand(OnSelectChange, CanSelectChange);
    
    }
        private RelayCommand _selectChangeCommand;
        public ICommand SelectChangeCommand { get { return _selectChangeCommand; } }
        private bool CanSelectChange()
        {
            return true;
        }
    
        private void OnSelectChange()
        {
            ..//do something in here when you change something in your combo box
        }
    }
