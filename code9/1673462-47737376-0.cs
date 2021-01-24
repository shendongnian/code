    public class RadioButtonsGroup : View
    {
        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemsSource),
            returnType: typeof(IEnumerable),
            declaringType: typeof(RadioButtonsGroup),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnItemsSourceChanged
        );
        public IEnumerable ItemsSource 
        { 
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty,value);
        }
        // gets called from BindableProperty 
        // whenever you assign a new value to ItemsSource property
        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var @this = bindable as RadioButtonsGroup;
            // unsubscribe from the old value
            var oldNPC = oldValue as INotifyPropertyChanged;
            if (oldNPC != null)
            {
                oldNPC.PropertyChanged -= @this.OnItemsSourcePropertyChanged;
            }
            var oldNCC = oldValue as INotifyCollectionChanged;
            if (oldNCC != null)
            {
                oldNCC.CollectionChanged -= @this.OnItemsSourceCollectionChanged;
            }
            // subscribe to the new value
            var newNPC = newValue as INotifyPropertyChanged;
            if (newNPC != null)
            {
                newNPC.PropertyChanged += @this.OnItemsSourcePropertyChanged;
            }
            var newNCC = newValue as INotifyCollectionChanged;
            if (newNCC != null)
            {
                newNCC.CollectionChanged += @this.OnItemsSourceCollectionChanged;
            }
            // inform the instance to do something
            @this.RebuildOnItemsSource();
        }
        private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // handle the collection changes
            throw new NotImplementedException();
        }
        private void OnItemsSourcePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // handle the property changes
            throw new NotImplementedException();
        }
        private void RebuildOnItemsSource()
        {
            if (ItemsSource == null)
            {
                // clear out all
            }
            else
            {
                // complete creation of all subviews
            }
        }
    }
