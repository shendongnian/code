    public class ColorChangedEventArgs
    {
        public Color Color { get; set; }
        public bool NewValue { get; set; }
    }
    public event EventHandler<ColorChangedEventArgs> ColorSettingChanged;
