    public class ViewModel
    {
        public ObservableCollection<ObservableVariable> Variables { get; set; }
        public ViewModel()
        {
            Variables = new ObservableCollection<ObservableVariable>();
            SelectAllCommand = new RelayCommand(SelectAll, ()=>true);
        }
        public RelayCommand SelectAllCommand { get; set; }
        public void SelectAll(object param)
        {
            foreach (var observableVariable in Variables)
            {
                observableVariable.Selected = (bool)param;
            }
        }
    }
