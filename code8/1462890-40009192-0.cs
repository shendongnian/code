        public class FlightGauge : Control
    {
        private GradientStopCollection _gradStops = new GradientStopCollection();
        public static DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(double), typeof(FlightGauge), new FrameworkPropertyMetadata(-100.0, new PropertyChangedCallback(MinValue_Changed)));
        public static DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(FlightGauge), new FrameworkPropertyMetadata(100.0, new PropertyChangedCallback(MaxValue_Changed)));
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(FlightGauge), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(Value_Changed)));
        public static DependencyProperty FillColorProperty = DependencyProperty.Register("FillColor", typeof(Color), typeof(FlightGauge), new FrameworkPropertyMetadata(Colors.Blue, new PropertyChangedCallback(FillColor_Changed)));
        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }
        private static void FillColor_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            FlightGauge thisClass = (FlightGauge)o;
            thisClass.SetFillColor();
        }
        private void SetFillColor()
        {
            //Put Instance FillColor Property Changed code here
        }
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static void Value_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            FlightGauge thisClass = (FlightGauge)o;
            thisClass.SetValue();
        }
        private void SetValue()
        {
            CalcTabStops();
        }
        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
        private static void MaxValue_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            FlightGauge thisClass = (FlightGauge)o;
            thisClass.SetMaxValue();
        }
        private void SetMaxValue()
        {
            CalcTabStops();
        }
        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        private static void MinValue_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            FlightGauge thisClass = (FlightGauge)o;
            thisClass.SetMinValue();
        }
        private void SetMinValue()
        {
            CalcTabStops();
        }
        private void CalcTabStops()
        {
            _gradStops.Clear();
            if (Value > 0)
            {
                double dLineValue = (1 - Value / MaxValue) /2;
                if (dLineValue > 0.49) dLineValue = 0.49;
                _gradStops.Add(new GradientStop(Colors.Transparent, 0.500));
                _gradStops.Add(new GradientStop(Colors.Transparent, 1.0));
                _gradStops.Add(new GradientStop(FillColor, 0.499));
                _gradStops.Add(new GradientStop(Colors.Transparent,  dLineValue));
                _gradStops.Add(new GradientStop(FillColor, dLineValue +0.001));
            }
            else
            {
                double dLineValue = 0.5 + (Value / MinValue / 2);
                if (dLineValue >= 1) dLineValue = 0.998;
                if (dLineValue == 0.5) dLineValue = 0.5001;
                _gradStops.Add(new GradientStop(Colors.Transparent, dLineValue +0.01));
                _gradStops.Add(new GradientStop(Colors.Transparent, 1.0));
                _gradStops.Add(new GradientStop(FillColor, dLineValue));
                _gradStops.Add(new GradientStop(Colors.Transparent, 0.5));
                _gradStops.Add(new GradientStop(FillColor, 0.501));
            }
            this.InvalidateVisual();
        }
        public FlightGauge()
        {
            BorderBrush = Brushes.Black;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            Brush brush = null;
            if (Value != 0)
            {
                LinearGradientBrush linBrush = new LinearGradientBrush();
                linBrush.StartPoint = new Point(0.5, 0);
                linBrush.EndPoint = new Point(0.5, 1);
                linBrush.GradientStops = _gradStops;
                brush = linBrush;
            }
            else
            {
                brush = Brushes.Transparent;
            }
            double dX = this.ActualWidth / 2;
            double dY = this.ActualHeight / 2;
            Pen pen = new Pen(BorderBrush, 2);
            drawingContext.DrawEllipse(brush, pen, new Point(dX, dY), dX, dY);
            drawingContext.DrawLine(pen, new Point(0, dY), new Point(this.ActualWidth, dY));
            base.OnRender(drawingContext);
        }
    }
