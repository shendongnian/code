    [ContentProperty("Bindings")]
    internal sealed class DelayedMultiBindingExtension : MarkupExtension, IMultiValueConverter, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Collection<BindingBase> Bindings { get; }
        public IMultiValueConverter Converter { get; set; }
        public object ConverterParameter { get; set; }
        public CultureInfo ConverterCulture { get; set; }
        public BindingMode Mode { get; set; }
        public UpdateSourceTrigger UpdateSourceTrigger { get; set; }
        private object _undelayedValue;
        private object _delayedValue;
        private DispatcherTimer _timer;
        public object CurrentValue
        {
            get { return _delayedValue; }
            set
            {
                _delayedValue = _undelayedValue = value;
                _timer.Stop();
            }
        }
        public int ChangeCount { get; private set; } // Public so Binding can bind to it
        public TimeSpan Delay
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }
        public DelayedMultiBindingExtension()
        {
            this.Bindings = new Collection<BindingBase>();
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = TimeSpan.FromMilliseconds(10);
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var valueProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (valueProvider == null) return null;
            var bindingTarget = valueProvider.TargetObject as DependencyObject;
            var bindingProperty = valueProvider.TargetProperty as DependencyProperty;
            var multi = new MultiBinding { Converter = this, Mode = Mode, UpdateSourceTrigger = UpdateSourceTrigger };
            foreach (var binding in Bindings) multi.Bindings.Add(binding);
            multi.Bindings.Add(new Binding("ChangeCount") { Source = this, Mode = BindingMode.OneWay });
            var bindingExpression = BindingOperations.SetBinding(bindingTarget, bindingProperty, multi);
            return bindingTarget.GetValue(bindingProperty);
        }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var newValue = Converter.Convert(values.Take(values.Length - 1).ToArray(),
                                             targetType,
                                             ConverterParameter,
                                             ConverterCulture ?? culture);
            if (Equals(newValue, _undelayedValue)) return _delayedValue;
            _undelayedValue = newValue;
            _timer.Stop();
            _timer.Start();
            return _delayedValue;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return Converter.ConvertBack(value, targetTypes, ConverterParameter, ConverterCulture ?? culture)
                            .Concat(new object[] { ChangeCount }).ToArray();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _delayedValue = _undelayedValue;
            ChangeCount++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangeCount)));
        }
    }
