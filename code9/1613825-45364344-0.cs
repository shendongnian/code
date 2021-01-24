    public class CustomPicker : Picker
    {
        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
    propertyName: "PlaceHolder",
    eturnType: typeof(string),
    declaringType: typeof(CustomPicker),
    defaultValue: default(string));
    
        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }
    
    }
