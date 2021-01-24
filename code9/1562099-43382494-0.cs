    public class AddEditCustomerViewModel : BindableBase
    {
        public string FirstName
        {
            get { return _editableCustomer.FirstName; }
            set
            {
                _editableCustomer.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
    
                if (!HasEmptyFields())
                {
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }
    }
