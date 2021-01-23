    List<Color> allColors = new List<Color>();
    foreach (KnownColor col in Enum.GetValues(typeof(KnownColor)))
    {
        Color c = Color.FromKnownColor(col);
        if(!c.IsSystemColor)
            allColors.Add(c);
    }   
