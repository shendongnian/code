    public class CustomScrollView : ScrollView
    {
        public static readonly BindableProperty IndexProperty = BindableProperty.Create (
            propertyName: nameof (Index),
            returnType: typeof (int),
            declaringType: typeof (CustomScrollView),
            defaultValue: 0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: HandleIndexChanged
        );
    
        static void HandleIndexChanged (BindableObject bindable, object oldValue, object newValue)
        {
            var view = (CustomScrollView)bindable;
            view.Index = (int)newValue;
    
            // Call your view.ScrollToAsync here.
            // Depending on the structure of your XAML you could call
            // it using view.Content to go through the control tree.
            // Such as (view.Content as StackLayout).Children[newValue]
        }
    
        public int Index
        {
            get { return (int)GetValue (IndexProperty); }
            set { SetValue (IndexProperty, value); }
        }
    }
