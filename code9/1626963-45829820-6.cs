    public class ComboItem
    {
      public string Color { get; private set; }
      public SolidColorBrush BackgroundColor { get; private set; }
      public SolidColorBrush ForegroundColor { get; private set; }
      public ComboItem(string color,  SolidColorBrush background, SolidColorBrush foreground)
      {
        Color = color;
        BackgroundColor = background;
        ForegroundColor = foreground;
      }
    }
