    public class ExtendedDatePicker : DatePicker
    {
        public delegate void DateSelectedHandler(object sender, DateChangedEventArgs e);
        public event DateSelectedHandler OnDateSelected;
        public static readonly BindableProperty NullableDateProperty =
            BindableProperty.Create(
                "NullableDate", 
                typeof(DateTime?), 
                typeof(ExtendedDatePicker), 
                null, 
                BindingMode.TwoWay);
    
        
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateDate();
        }
    
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
    
            if (propertyName == IsFocusedProperty.PropertyName)
            {
                if (IsFocused)
                {
                    if (!NullableDate.HasValue)
                    {
                        Date = (DateTime)DateProperty.DefaultValue;
                    }
                }
                else
                {
                    OnPropertyChanged(DateProperty.PropertyName);
                }
            }
    
            if (propertyName == DateProperty.PropertyName)
            {
                if (Date != default(DateTime))
                {
                    if (Date != NullableDate.GetValueOrDefault())
                        NullableDate = Date;
                }
                else
                {
                    if (NullableDate != null)
                        NullableDate = null;
                }
            }
    
            if (propertyName == NullableDateProperty.PropertyName)
            {
                if (NullableDate.HasValue)
                {
                    if (Date != NullableDate.GetValueOrDefault())
                        Date = NullableDate.Value;
                }
            }
        }
    
        private void UpdateDate()
        {
            if (NullableDate.HasValue)
            {
                Date = NullableDate.Value;
            }
            else
            {
                Date = (DateTime)DateProperty.DefaultValue;
            }
            OnDateSelected(this, null);
        }
    }
