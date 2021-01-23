    public interface IStyleStrategy<in T> where T : Control
    {
        void Style(T control);
    }
    
    public abstract class Theme : IStyleStrategy<Control>
    {
        public ButtonStyle ButtonStyle { get; }
        protected Theme(ButtonStyle buttonStyle)
        {
            ButtonStyle = buttonStyle;
        }
        // Apply this theme to all components recursively
        public void Style(Control parent)
        {
            if (parent is Button) ButtonStyle.Style((Button) parent);
            foreach (Control child in parent.Controls)
            {
                Style(child);
            }
        }
    }
    // Concrete implementation of a theme
    public class BlueTheme : Theme
    {
        public BlueTheme() : base(new BlueButtonStyle()) { }
    }
