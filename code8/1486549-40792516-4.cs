    public class ViewModel : ViewModelBase
    {
        public RelayCommand<string> RaiseWindow => new RelayCommand<string>(raiseWindow, canRaiseWindow);
        private bool canRaiseWindow(string nextWindowName)
        {
            // some logic
            return true;
        }
        private void raiseWindow(string nextWindowName)
        {
            RaiseWindowMessage message = new RaiseWindowMessage();
            message.WindowName = nextWindowName;
            message.ShowAsDialog = true;
            MessengerInstance.Send<RaiseWindowMessage>(message);
        }
    }
