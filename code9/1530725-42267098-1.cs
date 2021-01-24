    public class SvgGroup : Canvas
    {
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }
        public static readonly DependencyProperty FillProperty
       = DependencyProperty.Register(
             "Fill",
             typeof(Brush),
             typeof(SvgGroup), 
             new FrameworkPropertyMetadata(Brushes.Red, OnFillPropertyChanged)
         );
        private static void OnFillPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SvgGroup svg = (SvgGroup)d;
            if (e.NewValue != null && !e.NewValue.Equals(e.OldValue))
            {
                foreach (Shape shape in d.ShapeChildren)
                {
                    shape.Fill = (Brush)e.NewValue;
                }
                d.OnShapeBrushChanged(); // Note that you should call this method in some other places too.
            }
        }
        public Brush FillDifferentBrush
        {
            get { return (Brush)GetValue(IsFillDifferentProperty); }
        }
        public static readonly DependencyProperty FillDifferentProperty
            = DependencyProperty.Register(
                  "FillDifferentBrush",
                  typeof(Brush),
                  typeof(SvgGroup),
                  new PropertyMetadata(null)
              );
        void OnShapeBrushChanged()
        {
            Brush rtn = default(Brush);
            for (int i = 0; i < ShapeChildren.Count; i++)
            {
                Shape shape = ShapeChildren[i];
                if (i == 0) // First loop
                {
                    rtn = shape.Fill;
                }
                else if (rtn != shape.Fill) // Children shapes have different Fill value
                {
                    SetValue(FillDifferentProperty, default(Brush));
                }
                else
                    SetValue(FillDifferentProperty, rtn);
            }
        }
    }
