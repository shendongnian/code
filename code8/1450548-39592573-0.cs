    [Register ("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate  
    {
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            MessagingCenter.Subscribe<StartLongRunningTaskMessage> (this, "StartLongRunningTaskMessage", async message => {
                longRunningTaskExample = new iOSLongRunningTaskExample ();
                await longRunningTaskExample.Start ();
            });
    
            MessagingCenter.Subscribe<StopLongRunningTaskMessage> (this, "StopLongRunningTaskMessage", message => {
                longRunningTaskExample.Stop ();
            });
        }
    }
    public class iOSLongRunningTaskExample  
    {
        nint _taskId;
        CancellationTokenSource _cts;
    
        public async Task Start ()
        {
            _cts = new CancellationTokenSource ();
    
            _taskId = UIApplication.SharedApplication.BeginBackgroundTask ("LongRunningTask", OnExpiration);
    
            try {
                //INVOKE THE SHARED CODE
                var counter = new TaskCounter();
                await counter.RunCounter(_cts.Token);
    
            } catch (OperationCanceledException) {
            } finally {
                if (_cts.IsCancellationRequested) {
                    var message = new CancelledMessage();
                    Device.BeginInvokeOnMainThread (
                        () => MessagingCenter.Send(message, "CancelledMessage")
                    );
                }
            }
    
            UIApplication.SharedApplication.EndBackgroundTask (_taskId);
        }
    
        public void Stop ()
        {
            _cts.Cancel ();
        }
    
        void OnExpiration ()
        {
            _cts.Cancel ();
        }
    }
