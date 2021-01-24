            public int Count
            {
                get { return (int)GetValue(CountProperty); }
                set { SetValue(CountProperty , value); }
            }
    
            public static readonly DependencyProperty CountProperty =
                DependencyProperty.Register("Count" , typeof(int) , 
                    typeof(SomeThirdPartyControl) ,
                      new FrameworkPropertyMetadata(0 ,
                           FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
