     public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                _SyncContext = SynchronizationContext.Current;
                UpdateLabel();
            }
            SynchronizationContext _SyncContext = null;
            private async void UpdateLabel()
            {
                await Task.Run(() =>
                {
                    for (int i = 1; i < 11; i++)
                    {
                        Load(i);
                        Thread.Sleep(1000);
                    }
                });
    
            }
    
            private void Load(int i)
            {
                SendOrPostCallback updateUI = new SendOrPostCallback(arg =>
                {
                    yourLabelName.Content = $"{i}/10";
                });
    
                _SyncContext.Send(updateUI, null);
            }
        }
