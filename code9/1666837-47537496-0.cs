    public class RealParameter<T> : BindableBase2 where T : struct
    {
        private readonly IUnitService _unitService;
        private readonly IValueProvider<T> _valueProvider;
        private readonly IValueReceiver<T> _valueReceiver;
        private readonly IValueProvider<bool> _canUseProvider;
        private bool _canUseOverride = true;
        private readonly IValueProvider<bool> _readOnlyProvider;
        private bool _readOnlyOverride = false;
        private UnitType _unitType;
        private PrecisionType _precisionType;
        private string _customFormatString;
        private string _customUnitString;
        public RealParameter(
            IUnitService unitService,
            IValueProvider<T> valueProvider,
            IValueReceiver<T> valueReceiver = null,
            UnitType unitType = UnitType.None,
            PrecisionType precisionType = default(PrecisionType),
            IValueProvider<bool> canUseProvider = null,
            IValueProvider<bool> readOnlyProvider = null)
        {
            _unitService = unitService;
            _valueProvider = valueProvider;
            ...
        }
        public UnitType UnitType
        {
            get { return _unitType; }
            set
            {
                _unitType = value;
                OnPropertyChanged();
            }
        }
        public PrecisionType PrecisionType
        {
            get { return _precisionType; }
            set
            {
                _precisionType = value;
                OnPropertyChanged();
            }
        }
        public T Value
        {
            get ...
            set ...
        }
        public T LocalValue
        {
            // unit conversion goes here
            get ...
            set ...
        }
        [DependsOn(nameof(LocalValue))]
        [DependsOn(nameof(CustomFormatString))]
        [DependsOn(nameof(PrecisionType))]
        public string LocalValueDisplay
        {
            // formatting to / parsing from a string goes here
            get ...
            set ...
        }
        ...
    }
