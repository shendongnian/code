    [Flags]
    enum Colour
    {
        Black = 1,  // 0001
        Blue = 2,   // 0010
        Green = 4,  // 0100
        Yellow = 8  // 1000
    }
    ...
    private readonly int composite = Colour.Black | Colour.Blue | Colour.Green | Colour.Yellow;
    public bool IsColour (int value)
    {
        return this.composite | value == composite
    }
