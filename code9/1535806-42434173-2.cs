    public class CustomPopupViewModel : BindableBase, IInteractionRequestAware
    {
        public CustomPopupViewModel()
        {
            CancelCommand = new DelegateCommand(CancelInteraction);
        }
        private CustomPopupSelectionNotification notification;
        public INotification Notification
        {
            get
            {
                return this.notification;
            }
            set
            {
                if (value is CustomPopupSelectionNotification)
                {
                    this.notification = value as CustomPopupSelectionNotification;
                    this.OnPropertyChanged(() => this.Notification);
                }
            }
        }
        public Action FinishInteraction { get; set; }
        public System.Windows.Input.ICommand CancelCommand { get; private set; }
        public void CancelInteraction()
        {
            if (notification != null)
            {
                notification.SelectedItem = null;
                notification.Confirmed = false;
            }
            FinishInteraction();
        }
    }
