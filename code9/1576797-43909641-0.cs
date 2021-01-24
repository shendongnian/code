    public static readonly BindableProperty IsValidProperty = 
    BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailValidatorBehavior), null, 
    propertyChanged: OnIsValidChanged);
    static void OnIsValidChanged (BindableObject bindable, object oldValue, object newValue)
    {
        // Property changed implementation goes here
    }
