        public class ImageGallery : ScrollView
        {
            public static BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(ImageGallery), BindingMode.TwoWay,
                propertyChanging: (bindableObject, oldValue, newValue) =>
                {
                    ((ImageGallery)bindableObject).ItemsSourceChanging();
                },
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    ((ImageGallery)bindableObject).ItemsSourceChanged(bindableObject, oldValue, newValue);
                }
            );
    
            public IList ItemsSource
            {
                get { return (IList)GetValue(ItemsSourceProperty); }
                set { SetValue(ItemsSourceProperty, value); }
            }
    
            void ItemsSourceChanging()
            {
            }
    
            void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
            {
            }
        }
