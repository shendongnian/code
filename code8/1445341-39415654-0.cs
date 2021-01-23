    public class DateTimePickerEditor : DateTimePicker, ITypeEditor
    {
        public DateTimePickerEditor()
        {
            Format = DateTimeFormat.Custom;
            FormatString = "dd.MM.yyyy";
    
            TimePickerVisibility = System.Windows.Visibility.Collapsed;
            ShowButtonSpinner = false;
            AutoCloseCalendar = true;
        }
    
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            Binding binding = new Binding("Value");
            binding.Source = propertyItem;
            binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
    
            BindingOperations.SetBinding(this, ValueProperty, binding);
            return this;
        }
    }
