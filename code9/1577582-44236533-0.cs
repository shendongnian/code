    class CustomLifetimeManager : LifetimeManager
    {
        private object _Value;
        public override object GetValue()
        {
            return _Value;
        }
        public override void RemoveValue()
        {
            _Value = null;
        }
        public override void SetValue(object newValue)
        {
            _Value = newValue;
        }
    }
