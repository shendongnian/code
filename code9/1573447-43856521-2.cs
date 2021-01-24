    namespace PasswordBoxMVVM
    {
        public class PasswordViewModel : ViewModelBase
        {
            private bool isPasswordFieldEmpty;
            public bool IsPasswordFieldEmpty
            {
                get { return isPasswordFieldEmpty; }
                set
                {
                    isPasswordFieldEmpty = value;
                    RaisePropertyChanged();
                }
            }
    
            private SecureString password;
            public SecureString Password
            {
                get { return password; }
                set
                {
                    password = value;
                    RaisePropertyChanged();
                }
            }
    
            private bool isPassWordFieldDisabled;
            public bool IsPasswordFieldDisabled
            {
                get { return isPassWordFieldDisabled; }
                set
                {
                    isPassWordFieldDisabled = value;
                    RaisePropertyChanged();
                }
            }
    
            public ICommand ClickCommand { get { return new RelayCommand(doAction, canDoAction); } }
            public ICommand PasswordChangedCommand { get { return new RelayCommand(updatePassword, canUpdatePassword); } }
    
            public PasswordViewModel()
            {
                // Init conditions, need them to not get null reference at the start.
                isPassWordFieldDisabled = true;
                IsPasswordFieldEmpty = true;
            }
    
            private void doAction()
            {
                IsPasswordFieldDisabled = !IsPasswordFieldDisabled;
            }
    
            private bool canDoAction()
            {
                // Replace this with any condition that you need.
                return true;
            }
    
            private void updatePassword()
            {
                if (Password != null)
                {
                    if (Password.Length > 0)
                    {
                        isPasswordFieldEmpty = false;
                    }
                    else
                    {
                        isPasswordFieldEmpty = true;
                    }
                }
                else
                {
                    isPasswordFieldEmpty = true;
                }
            }
    
            private bool canUpdatePassword()
            {
                // Replace this with any condition that you need. 
                return true;
            }
        }
    }
