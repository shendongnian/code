       public partial class Window1: Window
        {
            public Window1()
            {
                InitializeComponent();
    
                _SyncContext = SynchronizationContext.Current;
    
                UpdateLabel();
            }
    
            SynchronizationContext _SyncContext = null;
    
            private void UpdateLabel()
            {
                SendOrPostCallback updateUI = new SendOrPostCallback(arg =>
                {
                    for (int i = 1; i < 11; i++)
                    {
                        yourLabelName.Content = $"{i}/10";
                        Thread.Sleep(1000);
                    }
    
                });
    
                _SyncContext.Send(updateUI, null);
            }
