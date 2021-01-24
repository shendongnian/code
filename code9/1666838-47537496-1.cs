    public class RealParameterVm<T> : BindableBase2 where T : struct
    {
        private readonly RealParameter<T> _parameter;
        private readonly string _title;
        public RealParameterVm(RealParameter<T> parameter, string title = null)
        {
            _parameter = parameter;
            _title = title;
            _parameter.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_parameter.LocalValueDisplay))
                    OnPropertyChanged(nameof(Value));
                if (e.PropertyName == nameof(_parameter.UnitDisplay))
                    OnPropertyChanged(nameof(Unit));
                ...
            };
        }
        public string Title => _title;
        public string Value
        {
            get { return _parameter.LocalValueDisplay; }
            set { _parameter.LocalValueDisplay = value; }
        }
        public string Unit => _parameter.UnitDisplay;
        public string ValueAndUnit => _parameter.LocalValueAndUnitDisplay;
        public bool CanUse => _parameter.CanUse;
        public bool IsReadOnly => _parameter.IsReadOnly;
        public T NumericGlobal => _parameter.Value;
        public T NumericLocal => _parameter.LocalValue;
    }
