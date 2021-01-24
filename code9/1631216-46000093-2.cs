    public class MainForm: Form {
        private Control currentControl;
        public void ChangeControl(Control newControl) {
            if(newControl == null) {
                throw new ArgumentNullException("newControl");
            }
            if(currentControl != null) {
                Me.Controls.Remove(currentControl);
                // Optionally you could dispose old control
                // currentControl.Dispose();
            }         
            Me.Controls.Add(newControl);
            currentControl = newControl;
        }
        
        // Optional generic method
        public void ChangeControl<TControl>() where TControl: Control, new() {
            this.Changecontrol(new TControl());
        }
        private void OnLoggedIn(Object sender, LoggedInEventArgs e) {
           this.ChangeControl<HomePageControl>();
        }
        private Login_ParentChanged(Object sender, EventArgs e) {
            var control = sender as LoginControl;
            if(control != null && control.Parent == null) {
                control.LoggedIn -= OnLoggedIn;
                control.ParentChanged -= Login_ParentChanged
            }
        }
        private void LogOut_Click(Object sender, EventArgs e) {
           var control = new LoginControl();
           control.LoggedIn += OnLoggedIn;
           this.ChangeControl(control);
           control.ParentChanged += Login_ParentChanged
        }
    }
    public class LoginControl: Control {
        public event EventHandler<LoggedInEventArgs> LoggedIn;
        private void LoginButton_Click(Object sender, EventArgs e) {
            if(DoLogin(...)) {
                if(LoggedIn != null) {
                   LoggedIn(this, new LoggedInEventArgs(...))
                }
                else {
                   // Show some error message
                }
            }
        }
    }
