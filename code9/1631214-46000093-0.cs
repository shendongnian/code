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
        //...
    }
