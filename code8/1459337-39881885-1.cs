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
    public class resButtonUsage
    {
        resButton resbuttonInstance;
        public resButtonUsage()
        {
            resbuttonInstance = new resButton();
            resbuttonInstance.yourEvent += resbuttonInstance_yourEvent;
        }
        void resbuttonInstance_yourEvent(object sender, EventArgs e)
        {
            // Your implementation
        }
    }
