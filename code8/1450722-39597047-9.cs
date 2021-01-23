    public class ColorChangedEventArgs
    {
        public Color Color { get; set; }
        public bool IsEnabled { get; set; }
    }
    public event EventHandler<ColorChangedEventArgs> ColorSettingsChanged;
