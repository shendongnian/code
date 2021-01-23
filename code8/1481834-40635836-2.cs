    [Flags]
    public enum SelectedColor // WRONG
    {
        None  = 0,
        Red   = 1,
        Blue  = 2,
        Green = 3  // <-- Not the next power of two!
    }
    selectedColor = SelectedColor.Red; // 1
    selectedColor |= SelectedColor.Green; // (1 | 3) == 3, which is still Green
