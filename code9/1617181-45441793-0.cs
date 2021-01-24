    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    namespace XamarinDependantProperty.Controls
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class CustomEntry : ContentView
        {
            public CustomEntry()
            {
                InitializeComponent();
                BindingContext = this;
            }
            public string TextValue
            {
                get { return (string)GetValue(TextValueProperty); }
                set {
                    SetValue(TextValueProperty, value);
                    OnPropertyChanged(nameof(TextIsVisible));
                }
            }
            public static BindableProperty TextValueProperty = BindableProperty.Create(nameof(TextValue), typeof(string), typeof(CustomEntry));
            public bool TextIsVisible => !String.IsNullOrEmpty(TextValue);
        }
    }
