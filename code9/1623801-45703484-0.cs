    public class ComboItem
    {
      public string Color { get; private set; }
      public string OppositeColor { get; private set; }
      public ComboItem(string color, string opposite)
      {
        Color = color;
        OppositeColor = opposite;
      }
    }
