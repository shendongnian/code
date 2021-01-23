    public IEnumerable ComboBoxItems
    {
         get { return (IEnumerable)GetValue(ValueItems); }
         set { SetValue(ValueItems, value); }
    }
    
    public static readonly DependencyProperty ValueItems = DependencyProperty.Register("ComboBoxItems", typeof(IEnumerable),
                    typeof(ComboBoxUC), new FrameworkPropertyMetadata { BindsTwoWayByDefault = false, DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
