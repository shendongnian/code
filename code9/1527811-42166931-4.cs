        public class VM : ViewModelBase, IDataErrorInfo
        {
            private bool showValidation;
            private int selected;
            public int Selected
            {
                get { return selected; }
                set
                {
                    selected = value;
                    showValidation = true;
                    OnPropertyChanged("Selected");
                }
            }
            DelegateCommand saveCmd;
            public ICommand SaveCmd
            {
                get
                {
                    if (saveCmd == null)
                    {
                        saveCmd = new DelegateCommand(_ => RunSaveCmd(), _ => CanSaveCmd());
                    }
                    return saveCmd;
                }
            }
            private bool CanSaveCmd()
            {
                return true;
            }
            private void RunSaveCmd()
            {
                showValidation = true;
                OnPropertyChanged("Selected");
            }
