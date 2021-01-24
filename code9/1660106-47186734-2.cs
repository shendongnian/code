    public class EnableDisableAppearance : Attribute
    {
        public event EventHandler AppearanceChanged;
        protected virtual void OnAppearanceChanged()
        {
            AppearanceChanged?.Invoke(this, EventArgs.Empty);
        }
        [Description("Color when enabled"), ...]
        public Color Enabled
        {
            get { return enabled; }
            set {
                if (value != enabled) {
                    enabled = value;
                    OnAppearanceChanged();
                }
            }
        }
        // Do the same in the Disabled property...
        ...
    }
