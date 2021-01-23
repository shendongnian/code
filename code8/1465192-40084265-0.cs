    public class InputEventArgs : EventArgs
    {
        public string Input { get; private set; }
        
        public InputEventArgs(string input)
        {
            Input = input;
        }
    }
    
    public class InputDialog : Form
    {
        public EventHandler<InputEventArgs> InputSet;
    
        private void OkClick(object sender, EventArgs e)
        {
            var ev = InputSet;
    
            if (ev != null)
            {
                ev(this, new InputEventArgs(txtInput.Text));
            }
        }
    }
