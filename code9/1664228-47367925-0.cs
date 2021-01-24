       public Color _color
                {
                    get { return (Color)GetValue(ColorProperty); }
                    set { SetValue(ColorProperty, value); }
                }
        
                public static readonly DependencyProperty ColorProperty = 
       DependencyProperty.Register("_color", typeof(Color), typeof(Fileentity), null);
