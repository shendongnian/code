    public class MainForm: Form {
        //...
        private Control currentControl;
    
        public void ChangeControl(Control newControl) {
            if(newControl == null) {
                throw new ArgumentNullException("newControl");
            }
            if(currentControl != null) {
                Me.Controls.Remove(currentControl);
            }
            Me.Controls.Add(newControl);
            currentControl = newControl;
        }
        public void ShowHomePage() {
            // You could use a previously created control
            this.ChangeControl(this.homePageControl);
            // Or create a new one.
            // this.ChangeControl(new HomePageControl());
        }
        //...
    }
    public class LoginControl: Control {
        private void LoginButton_Click(Object sender, EventArgs e) {
            if(DoLogin(...)) {
                ((MainForm)this.Parent).ShowHomePage()
            }
            else {
                // Show some error message
            }
        }
    }
