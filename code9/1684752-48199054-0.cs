    public class AdvancedStretchTextBlock : TextBlock
    {
        /// <summary>
        /// Defines charachter/letter spacing
        /// </summary>
        public int Tracking
        {
            get => (int)GetValue(TrackingProperty);
            set => SetValue(TrackingProperty, value);
        }
        public static readonly DependencyProperty TrackingProperty =
            DependencyProperty.Register("Tracking", typeof(int), typeof(AdvancedStretchTextBlock),
                new UIPropertyMetadata(0,
                    TrackingPropertyChanged));
        static void TrackingPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (!(o is AdvancedStretchTextBlock tb) || String.IsNullOrEmpty(tb.Text))
                return;
            tb._tracking.X = (int)e.NewValue;
            tb._trackingAlignment.X = -(int)e.NewValue * tb.Text.Length;
            if (tb._lastTrackingTextLength == tb.Text.Length)
                return; // Avoid re-creating effects when you don't have to..
            // Remove unused effects (string has shortened)
            while (tb._trackingEffects.Count > tb.Text.Length)
            {
                tb.TextEffects.Remove(tb._trackingEffects[tb._trackingEffects.Count - 1]);
                tb._trackingEffects.RemoveAt(tb._trackingEffects.Count - 1);
            }
            tb._lastTrackingTextLength = tb.Text.Length;
            // Add missing effects (string has grown)
            for (int i = tb._trackingEffects.Count; i < tb.Text.Length; i++)
            {
                var fx = new TextEffect()
                {
                    PositionCount = i,
                    Transform = tb._tracking
                };
                tb._trackingEffects.Add(fx);
                tb.TextEffects.Add(fx);
            }
            // Ugly hack to fix overall alignment
            tb.RenderTransform = tb._trackingAlignment;
        }
        private readonly TranslateTransform _tracking = new TranslateTransform();
        private readonly TranslateTransform _trackingAlignment = new TranslateTransform();
        private readonly List<TextEffect> _trackingEffects = new List<TextEffect>();
        int _lastTrackingTextLength;
    }
