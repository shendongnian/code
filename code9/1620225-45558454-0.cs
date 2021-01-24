    public class ZoomImage : Image
    {
        private const double MIN_SCALE = 1;
        private const double MAX_SCALE = 1.5;
        private const double OVERSHOOT = 0.9;
        private double StartScale;
        private double LastX, LastY;
        public ZoomImage()
        {
            var pinch = new PinchGestureRecognizer();
            pinch.PinchUpdated += OnPinchUpdated;
            GestureRecognizers.Add(pinch);
            //don't register the Pan gesture and Tap gesture for zoom in/out
            //var pan = new PanGestureRecognizer();
            //pan.PanUpdated += OnPanUpdated;
            //GestureRecognizers.Add(pan);
            //var tap = new TapGestureRecognizer { NumberOfTapsRequired = 2 };
            //tap.Tapped += OnTapped;
            //GestureRecognizers.Add(tap);
            Scale = MIN_SCALE;
            TranslationX = TranslationY = 0;
            AnchorX = AnchorY = 0;
        }
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            Scale = MIN_SCALE;
            TranslationX = TranslationY = 0;
            AnchorX = AnchorY = 0;
            return base.OnMeasure(widthConstraint - 50, heightConstraint);
        }
        
        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            switch (e.Status)
            {
                case GestureStatus.Started:
                    StartScale = Scale;
                    AnchorX = e.ScaleOrigin.X;
                    AnchorY = e.ScaleOrigin.Y;
                    break;
                case GestureStatus.Running:
                    
                    double current = Scale + (e.Scale - 1) * StartScale;
                    //Scale = Clamp(current, MIN_SCALE * (1 - OVERSHOOT), MAX_SCALE * (1 + OVERSHOOT));
                    var parent = (StackLayout)this.Parent;
                    var child = parent.Children[1];
                    if (child is Label)
                    {
                        (child as Label).Text = Clamp(current, MIN_SCALE, MAX_SCALE).ToString();
                    }
                    Scale = Clamp(current, MIN_SCALE, MAX_SCALE);
                    break;
                case GestureStatus.Completed:
                    //Scale is already limited to Min_SCALE and MAX_SCALE, the following codes is not necessary
                    //if (Scale > MAX_SCALE)
                    //this.ScaleTo(MAX_SCALE, 50, Easing.SpringOut);
                    //else if (Scale < MIN_SCALE)
                    //this.ScaleTo(MIN_SCALE, 50, Easing.SpringOut);
                        break;
            }
        }
        private T Clamp<T>(T value, T minimum, T maximum) where T : IComparable
        {
            if (value.CompareTo(minimum) < 0)
                return minimum;
            else if (value.CompareTo(maximum) > 0)
                return maximum;
            else
                return value;
        }
    }
