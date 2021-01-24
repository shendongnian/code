       /// <summary>A generic converter.</summary>
    public interface IConverter: IValueConverter    
    {
        /// <summary>The input value.</summary>
        object Input { get; set; }
        /// <summary>The output value.</summary>
        object Output { get; set; }
    }
    /// <summary>A service that provides conversion capabilities to dependency objects via an attached property.</summary>
    public abstract class ConverterService : DependencyObject
    {
        /// <summary>The Converter dependency property.</summary>
        public static readonly DependencyProperty ConverterProperty;
        /// <summary>The Converters dependency property which is a collection of Converter.</summary>
        public static readonly DependencyProperty ConvertersProperty;
        static ConverterService()
        {
            ConverterProperty = DependencyProperty.RegisterAttached("Converter",
                                                                    typeof(IConverter),
                                                                    typeof(ConverterService),
                                                                    new PropertyMetadata(null));
            ConvertersProperty = DependencyProperty.RegisterAttached("Converters",
                                                                    typeof(IList<IConverter>),
                                                                    typeof(ConverterService),
                                                                    new PropertyMetadata(new List<IConverter>()));
        }
        /// <summary>Property getter for attached property Converter.</summary>
        /// <param name="element">The dependency object to which the attached property applies.</param>
        /// <returns>Returns the converter associated with the specified dependency object.</returns>
        public static IConverter GetConverter(DependencyObject element)
        {
            return (IConverter)element.GetValue(ConverterProperty);
        }
        /// <summary>Property getter for attached property Converter.</summary>
        /// <param name="element">The dependency object to which the attached property applies.</param>
        /// <param name="value">The converter to associate.</param>
        public static void SetConverter(DependencyObject element, IConverter value)
        {
            element.SetValue(ConverterProperty, value);
        }
        /// <summary>Property getter for attached property Converters.</summary>
        /// <param name="element">The dependency object to which the attached property applies.</param>
        /// <returns>Returns the collection of converters associated with the specified dependency object.</returns>
        public static IList<IConverter> GetConverters(DependencyObject element)
        {
            return (IList<IConverter>)element.GetValue(ConverterProperty);
        }
        /// <summary>Property getter for attached property Converters.</summary>
        /// <param name="element">The dependency object to which the attached property applies.</param>
        /// <param name="value">The converters to associate.</param>
        public static void SetConverters(DependencyObject element, IList<IConverter> value)
        {
            element.SetValue(ConverterProperty, value);
        }
    }
    /// <summary>A strongly-typed base converter.</summary>
    /// <typeparam name="Tin">The input type.</typeparam>
    /// <typeparam name="Tout">The output type.</typeparam>
    public abstract class BaseConverter<Tin, Tout>: DependencyObject, IConverter
    {
        /// <summary>The Input dependency property.</summary>
        public static readonly DependencyProperty InputProperty;
        /// <summary>The Output dependency property.</summary>
        public static readonly DependencyProperty OutputProperty;
        static BaseConverter()
        {
            OutputProperty = DependencyProperty.Register("Output",
                                                         typeof(Tout),
                                                         typeof(BaseConverter<Tin, Tout>),
                                                         new PropertyMetadata(GetDefault(typeof(Tout)), OutChanged));
            InputProperty = DependencyProperty.Register("Input",
                                                         typeof(Tin),
                                                         typeof(BaseConverter<Tin, Tout>),
                                                         new PropertyMetadata(GetDefault(typeof(Tin)), InChanged));
        }
        /// <summary>Gets or sets the input value to convert from.</summary>
        public Tin Input
        {
            get { return (Tin)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
        /// <summary>Gets or sets the output value to convert to.</summary>
        public Tout Output
        {
            get { return (Tout)GetValue(OutputProperty); }
            set { SetValue(OutputProperty, value); }
        }
        /// <summary>Gets the from type.</summary>
        public static Type From
        {
            get { return typeof(Tin); }
        }        
        /// <summary>Gets the to type.</summary>
        public static Type To
        {
            get { return typeof(Tout); }
        }
        #region IConverter
        object IConverter.Input { get => Input; set => Input = (Tin)value; }
        object IConverter.Output { get => Output; set => Output = (Tout)value; }
        #endregion
        #region IValueConverter
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            return Convert((Tin)value, parameter, language);
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ConvertBack((Tout)value, parameter, language);
        }
        #endregion
        /// <summary>Converts an input value into an output value.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="parameter">An optional parameter to pass onto the conversion process (from IValueConverter).</param>
        /// <param name="language">An optional language parameter to pass onto the conversion process (from IValueConverter).</param>
        /// <returns>Returns the converted value.</returns>
        protected abstract Tout Convert(Tin value, object parameter, string language);
        /// <summary>Converts back an output value into its original input.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="parameter">An optional parameter to pass onto the conversion process (from IValueConverter).</param>
        /// <param name="language">An optional language parameter to pass onto the conversion process (from IValueConverter).</param>
        /// <returns>Returns the converted value from output to input.</returns>
        protected abstract Tin ConvertBack(Tout value, object parameter, string language);
        private static object GetDefault(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
        private static void InChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as BaseConverter<Tin, Tout>;
            control.Output = (Tout)((d as IValueConverter).Convert(e.NewValue, typeof(Tout), null, null));
        }
        private static void OutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as BaseConverter<Tin, Tout>;
            //control.Input = (Tin)((d as IValueConverter).ConvertBack(e.NewValue, typeof(Tin), null, null));
        }        
    }
        /// <summary>Converts Double to and from GridLength.</summary>
    public sealed class DoubleToGridLengthConverter : BaseConverter<double?, GridLength?>
    {
        /// <summary>The GridUnit dependency property.</summary>
        public static readonly DependencyProperty GridUnitProperty;
        static DoubleToGridLengthConverter()
        {
            GridUnitProperty = DependencyProperty.Register("GridUnit",
                                                           typeof(GridUnitType),
                                                           typeof(DoubleToGridLengthConverter),
                                                           new PropertyMetadata(GridUnitType.Auto, UnitChanged));
        }
        /// <summary>Gets or sets the type of grid unit to be used in the conversions.</summary>
        public GridUnitType GridUnit
        {
            get { return (GridUnitType)GetValue(GridUnitProperty); }
            set { SetValue(GridUnitProperty, value); }
        }
        protected override GridLength? Convert(double? value, object parameter, string language)
        {
            return value == null || !value.HasValue
                   ? new GridLength()
                   : new GridLength(value.Value, this.GridUnit);
        }
        protected override double? ConvertBack(GridLength? value, object parameter, string language)
        {
            return value == null || !value.HasValue
                   ? default(double?)
                   : value.Value.Value;
        }
        private static void UnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as DoubleToGridLengthConverter;
            control.Output = control.Convert(control.Input, null, null);
        }
    }
