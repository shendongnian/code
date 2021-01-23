    // One array created and stored for later use ..
    private static string[] Colors = { "red", "green", "blue" };
    // .. independent of number of times this method is called
    public Boolean IsRgb(string color)
    {
        return Colors.Contains(color);
    }
