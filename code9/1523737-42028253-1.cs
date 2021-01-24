    public class ValueArgs : EventArgs
    {
        public bool ValueUpdated { get; set; }
    
        public ValueArgs() { }
        public ValueArgs(int valueUpdated)
        {
            ValueUpdated = valueUpdated;
        }
    }
