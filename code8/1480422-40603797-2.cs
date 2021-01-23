    public class CustomEventArgs : EventArgs
    {
        public int Value { get; set; }
        public CustomEventArgs(int value)
        {
            Value = value;
        }
    }
