        /// <summary>Aspect ratios.</summary>
    public enum AspectRatio
    {
        /// <summary>Portrait.</summary>
        Portrait,
        /// <summary>Landscape.</summary>
        Landscape
    }
    /// <summary>A state trigger based on the aspect ratio of the window.</summary>
    public class WindowAspectRatioTrigger: StateTriggerBase
    {
        /// <summary>The target orientation.</summary>
        private static readonly DependencyProperty OrientationProperty;
        static WindowAspectRatioTrigger()
        {
            OrientationProperty = DependencyProperty.Register("Orientation",
                                                              typeof(AspectRatio),
                                                              typeof(WindowAspectRatioTrigger),
                                                              new PropertyMetadata(AspectRatio.Landscape, new PropertyChangedCallback(DesiredAspectRatioChanged)));
        }
        public WindowAspectRatioTrigger()
        {
            this.OnAspectRatioChanged(this.Orientation);
            Window.Current.SizeChanged += Current_SizeChanged;
        }
        /// <summary>Gets or sets the desired aspect ratio for the trigger.</summary>
        public AspectRatio Orientation
        {
            get { return (AspectRatio)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        private async void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                SetActive(IsActive(e.Size, this.Orientation));
            });
        }
        private static void DesiredAspectRatioChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as WindowAspectRatioTrigger;
            control.OnAspectRatioChanged((AspectRatio)e.NewValue);
        }
        private static bool IsActive(Size windowSize, AspectRatio aspectRatio)
        {
            var currentOrientation = windowSize.Width >= windowSize.Height
                                     ? AspectRatio.Landscape
                                     : AspectRatio.Portrait;
            return aspectRatio == currentOrientation;
        }
        private async void OnAspectRatioChanged(AspectRatio aspectRatio)
        {
            var dimensions = Window.Current.Bounds;
            var size = new Size(dimensions.Width, dimensions.Height);
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                SetActive(IsActive(size, aspectRatio));
            });
        }
    }
