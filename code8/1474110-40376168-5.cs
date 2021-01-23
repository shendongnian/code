    public enum Color
    {
        Red = 1,
        Green = 2,
    }
    var color = Color.Green;
    var colorAsInt = color.Wrap().EnumValue;
