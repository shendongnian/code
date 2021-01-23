    public class resButton : TextBox
    {
        [Browsable(true)]
        [Description("state of TextBox"), Category("Data")]
        public string textBoxState
        {
            get { return this.AccessibleDescription; }
            set
            {
                this.AccessibleDescription = value;
                if (yourEvent != null)
                    yourEvent(this, new EventArgs());
            }
        }
        public event EventHandler yourEvent;
    }
