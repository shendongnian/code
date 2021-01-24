    public class SoftKeyboardDisabledEntry : Entry
    {
        public static readonly new BindableProperty TextProperty = BindableProperty.Create(propertyName: "Text",
           returnType: typeof(string),
           declaringType: typeof(SoftKeyboardDisabledEntry),
           defaultValue: default(string));
        public new string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
