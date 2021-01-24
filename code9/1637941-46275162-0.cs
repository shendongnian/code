        public class MyButton : Button 
        {
            public static readonly BindableProperty LabelOneTextProperty = BindableProperty.Create("LabelOneText", typeof(string), typeof(MyButton), defaultBindingMode: BindingMode.TwoWay);
            public static readonly BindableProperty LabelTwoTextProperty = BindableProperty.Create("LabelTwoText", typeof(string), typeof(MyButton), defaultBindingMode: BindingMode.TwoWay);
    
    
            public string LabelOneText
            {
                get { return (string)GetValue(LabelOneTextProperty); }
                set { SetValue(LabelOneTextProperty, value); }
            }
    
            public string LabelTwoText
            {
                get { return (string)GetValue(LabelTwoTextProperty); }
                set { SetValue(LabelTwoTextProperty, value); }
            }
        }
