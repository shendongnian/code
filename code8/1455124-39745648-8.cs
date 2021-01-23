    public class Events
    {
        public event Action<int> OnValueChanged;
        public int Value { get; set; }
        public void ChangeValue(int i)
        {
            Value = i;
            if(OnValueChanged != null)
                OnValueChanged(Value);
        }
    }
