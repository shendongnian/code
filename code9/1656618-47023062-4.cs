    public partial class MyView : UserControl
    {
        public MyView()
        {
             InitializeComponent();
             Messenger.Default.Register<ChangeBackgroundMessage>(this, m => ReceiveChangeBackgroundMessage(m);
        } 
        private void ReceiveChangeBackgroundMessage(ChangeBackgroundMessage m)
        {
              // If you need to ensure this executes only on UI thread, use the
              // DispatcherHelper class
              DispatcherHelper.CheckBeginInvokeOnUI(() => button2.Background = m.TheColor);
        }
        
    }
    
