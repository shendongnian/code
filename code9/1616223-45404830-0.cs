    public class Level {
        private double val;
        public double Value {
            get {
                return val;
            }
            set {
                OnSetValue(value);
                val = value;
            }
        }
        protected abstract void OnSetValue(double val);
        ...
    }
    public class Potentiometer : Level {
        protected void OnSetValue(double val) {
            ...
        }
    }
