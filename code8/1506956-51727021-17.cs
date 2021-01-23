        public partial class AppDelegate /* ... */
        {
            public override bool FinishedLaunching(UIApplication app, NSDictionary options)
            {
                // ...
                var success = base.FinishedLaunching(app, options);
                if (success) {
                    SessionManager.Instance.SessionDuration = TimeSpan.FromSeconds(10);
                    SessionManager.Instance.OnSessionExpired += HandleSessionExpired;
                    var allGesturesRecognizer = new AllGesturesRecognizer(delegate
                    {
                        SessionManager.Instance.ExtendSession();
                    });
                    this.Window.AddGestureRecognizer(allGesturesRecognizer);
                }
                return success;
            }
            async void HandleSessionExpired(object sender, EventArgs e)
            {
                await App.instance.DoLogoutAsync();
            }
            class AllGesturesRecognizer: UIGestureRecognizer {
                public delegate void OnTouchesEnded();
                private OnTouchesEnded touchesEndedDelegate;
                public AllGesturesRecognizer(OnTouchesEnded touchesEnded) {
                    this.touchesEndedDelegate = touchesEnded;
                }
                public override void TouchesEnded(NSSet touches, UIEvent evt)
                {
                    this.State = UIGestureRecognizerState.Failed;
                    this.touchesEndedDelegate();
                    base.TouchesEnded(touches, evt);
                }
            }
        }
