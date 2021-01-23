    public abstract class Theme
    {
        public delegate void ButtonStyler(Button button);
        public ButtonStyler StyleButton { get; }
        protected Theme(ButtonStyler styleButton)
        {
            StyleButton = styleButton;
        }
        // Apply this theme to all components recursively
        public void Style(Control parent)
        {
            if (parent is Button) StyleButton((Button) parent);
            foreach (Control child in parent.Controls) Style(child);
        }
    }
    public class BlueTheme : Theme
    {
        public BlueTheme() : base(
            button =>
            {
                button.BackColor = Color.DeepSkyBlue;
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
            }) {}
    }
