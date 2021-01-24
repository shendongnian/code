           public Brush NewColor
            {
                get { return (Brush)GetValue(NewColorProperty); }
                set { SetValue(NewColorProperty , value); }
            }
    
            public static readonly DependencyProperty NewColorProperty =
                DependencyProperty.Register("NewColor" , typeof(Brush) , 
                    typeof(ChangeColor) ,
                      new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black) ,
                           FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
