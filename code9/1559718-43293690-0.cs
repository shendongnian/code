    public class FloatIncreasing
    {
        private float _Value;
        public float Value {
            get {
                return _Value;
            }
            set {
                ValueChangeEvent(this, _Value >= value);
                _Value = value;
            }
        }
        public Boolean HasIncreased { get; private set; }
        public event EventHandler<Boolean> ValueChangeEvent;
        public FloatIncreasing() {
            this.ValueChangeEvent += OnValueChanged; 
        }
        public virtual void OnValueChanged(Object sender, Boolean value) {
            HasIncreased = value;
            // You can add a more appropriate default behavior in here. 
        }
    }
