    public class JoyStick
    {
        private int key;
        private string value;
        public JoyStick() { }
        public int Key
        {
            set { this.key = value; }
            get { return this.key; }
        }
        public string Value
        {
            set{this.value=value;}
            get { return this.value; }
        }
    }
