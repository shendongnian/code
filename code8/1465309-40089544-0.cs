    public static readonly BindableProperty TestVarProperty =
       BindableProperty.Create<SkiaView, string>(rv => rv.TestVar, null,
           BindingMode.OneWayToSource);
        public string TestVar
        {
            get { return (string)GetValue(TestVarProperty); }
            set { SetValue(TestVarProperty, value); }
        }
