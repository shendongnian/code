      public SomeClass() {
        PermissionEvent += this_PermissionEvent;
        }
        
        private void this_PermissionEvent(sender object, PermissionEventArgs args) {
    // MessageBox.Show(...) waits until you closed the window (yes/no/closed/terminated)
        if (MessageBox.Show("Do you want execute?","Grant Permission",MessageBoxButtons.YesNo) == DialogResult.Yes) {
    args.Handle = true;
    }
        }
        
        private event EventHandler<PermissionEventArgs> PermissionEvent;
        
        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
        switch (e.Result.Text)
        {                
        case "hey computer, start spotify":
        //
        var args = new PermissionEventArgs();
        PermissionEvent?.Invoke(args)
        
        if (args.Handle) {
        // do something here
        }
        break;
        }
        }
        
        public class PermissionEventArgs : EventArgs {
        public bool Handle = false
        }
