    public class AngleUserControl : ...
    {
        static AngleUserControl()
        {
            ComboBoxWidthProperty.OverrideMetadata(
                typeof(AngleUserControl),
                new PropertyMetadata(175d));
        }
    }
