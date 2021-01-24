        public class ExLabel : Label
        {
            public static readonly BindableProperty FontNamedSizeProperty =
                BindableProperty.Create(
                    "FontNamedSize", typeof(NamedSize), typeof(ExLabel),
                    defaultValue: default(NamedSize), propertyChanged: OnFontNamedSizeChanged);
            public NamedSize FontNamedSize
            {
                get { return (NamedSize)GetValue(FontNamedSizeProperty); }
                set { SetValue(FontNamedSizeProperty, value); }
            }
            private static void OnFontNamedSizeChanged(BindableObject bindable, object oldValue, object newValue)
            {
                ((ExLabel)bindable).OnFontNamedSizeChangedImpl((NamedSize)oldValue, (NamedSize)newValue);
            }
            protected virtual void OnFontNamedSizeChangedImpl(NamedSize oldValue, NamedSize newValue)
            {
                FontSize = Device.GetNamedSize(FontNamedSize, typeof(Label));
            }
        }
        <!-- Usage -->
        <local:ExLabel HorizontalOptions="Center" VerticalOptions="Center" Text="This is a custom label">
            <local:ExLabel.FontNamedSize>
                <OnPlatform x:TypeArguments="NamedSize"
                    iOS="Large"
                    Android="Medium" />
            </local:ExLabel.FontNamedSize>
        </local:ExLabel>
