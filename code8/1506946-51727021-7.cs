        public class MainActivity /* ... */ {
            protected override void OnCreate(Bundle bundle)
            {   
                // ...
                SessionManager.Instance.SessionDuration = TimeSpan.FromSeconds(10);
                SessionManager.Instance.OnSessionExpired = HandleSessionExpired;
            }
            public override void OnUserInteraction()
            {
                base.OnUserInteraction();
                SessionManager.Instance.ExtendSession();
            }
            async void HandleSessionExpired(object sender, EventArgs e)
            {
                await App.Instance.DoLogoutAsync();
            }    
        }
