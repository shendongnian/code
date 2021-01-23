    public class WebTabItemVievModel: ViewModelBase
    {
      
        public WebTabItemVievModel()
        {
            
            NavigatingMVCommand = new RelayCommand<NavigatingCancelEventArgs>(NavigatingMethod);
            
        }
    
    
    
        public ICommand NavigatingMVCommand { get;  set; }
        private void NavigatingMethod(NavigatingCancelEventArgs e)
        {
            Messenger.Default.Send<NotificationMessage <UriChangedMSG>>(new NotificationMessage<UriChangedMSG> (new UriChangedMSG { NewUri = e.Uri.AbsoluteUri },"test"));
            CurrentUri = e.Uri.AbsoluteUri;
            NotificationRibbonText = e.Uri.AbsoluteUri;
        }
