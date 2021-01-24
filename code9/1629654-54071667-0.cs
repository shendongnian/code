      public static readonly BindableProperty ItemLabelProperty = 
      BindableProperty.Create(nameof(ItemLabel), typeof(string), 
      typeof(DetailsLineItemControl), default(string), BindingMode.OneWay);
        public string ItemLabel
        {
            get
            {
                var value = (string)GetValue(ItemLabelProperty);
                return !string.IsNullOrEmpty(value) ? value.ToUpper() : value;
            }
            set
            {
                SetValue(ItemLabelProperty, value);
            }
        }
