    namespace WpfExampleControlLibrary
    {
        public class BindingProxy : Freezable
        {
            #region Override Freezable Abstract Parts
            protected override Freezable CreateInstanceCore()
            {
                return new BindingProxy();
            }
    
            #endregion Override Freezable Abstract Parts
    
            #region Dependency Properties
    
            // Using a DependencyProperty as the backing store for Data.
            // This enables animation, styling, binding, etc...
            public static PropertyMetadata DataMetadata = new PropertyMetadata(null);
            public static readonly DependencyProperty DataProperty
                = DependencyProperty.Register(
                    "Data",
                    typeof(object),
                    typeof(BindingProxy),
                    DataMetadata);
    
            public object Data
            {
                get { return (object)GetValue(DataProperty); }
                set { SetValue(DataProperty, value); }
            }
    
            #endregion Dependency Properties
        }
    }
