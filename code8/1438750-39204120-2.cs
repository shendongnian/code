    <UserControl x:Class="ClientModule.Views.MyFancyErrorPopup"
         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
         xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
         xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
         xmlns:prism="http://prismlibrary.com/"
         prism:ViewModelLocator.AutoWireViewModel="True"
         mc:Ignorable="d" 
         d:DesignHeight="300" d:DesignWidth="300">
        <StackPanel Orientation="Vertical">
            <TextBlock Text={Binding Message}" TextWrapping="Wrap"/>
            <Button Content="Ok" Command="{Binding OkCommand}"/>
        </StackPanel>
    </UserControl>
    
    class MyFancyErrorPopupViewModel : BindableBase, IInteractionRequestAware
    {
        public MyFancyErrorPopupViewModel()
        {
            OkCommand = new DelegateCommand( OnOk );
        }
        public DelegateCommand OkCommand
        {
            get;
        }
        public string Message
        {
            get { return (_notification?.Content as string) ?? "null"; }
        }
        #region IInteractionRequestAware
        public INotification Notification
        {
            get { return _notification; }
            set
            {
                SetProperty( ref _notification, value as Notification );
                OnPropertyChanged( () => Message );
            }
        }
        public Action FinishInteraction
        {
            get;
            set;
        }
        #endregion
        #region private
        private Notification _notification;
        private void OnOk()
        {
            FinishInteraction();
        }
        #endregion
    }
