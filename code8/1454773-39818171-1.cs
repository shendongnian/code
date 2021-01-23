    public abstract class ButtonStyle : IStyleStrategy<Button>
    {
        public abstract void Style(Button button);
    }
    // Concrete implementation of a button styler
    public class BlueButtonStyle : ButtonStyle
    {
        public override void Style(Button button)
        {
            button.BackColor = Color.DeepSkyBlue;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
        }
    }
