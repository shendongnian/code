    namespace MyClass.ViewModels
    {
      public class MyContentDialogViewModel : ViewModelBase
      {
        private ICommand m_myCancelableCommand;
        private bool m_cancel;
    
        public ICommand MyCancelableCommand=> m_myCancelableCommand ?? (m_myCancelableCommand = new RelayCommand<object>(CancelableSave));
        public bool Cancel
        {
          get
          {
            return m_cancel;
          }
          set
          {
            m_cancel = value;
            RaisePropertyChanged("Cancel");
          }
        }
    
        private void CancelableSave(object obj)
        {
          Cancel = !ValidateDialog();
        }
    
        private bool ValidateDialog()
        {
          return true// if saving successfull otherwise false
        }
      }
    }
