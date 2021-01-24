    public partial class ZButton : Button
    {
        private void Backcolor_AppearanceChanged(object sender, EventArgs e)
        {
            SetAppearance();
        }
        [Description("The background color ...]
        public new EnableDisableAppearance BackColor
        {
            get { return backcolor; }
            set {
                if (value != backcolor) {
                    if (backcolor != null) {
                        backcolor.AppearanceChanged -= Backcolor_AppearanceChanged;
                    }
                    backcolor = value;
                    SetAppearance();
                    if (backcolor != null) {
                        backcolor.AppearanceChanged += Backcolor_AppearanceChanged;
                    }
                }
            }
        }
        // Same for ForeColor...
        ...
    }
