    private Color GetRandomColor(Random randomGen = new Random())
    {
        Color randomColor = Color.Red;
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        KnownColor[] badColors = { KnownColor.AliceBlue };
        IEnumerable<KnownColor> okColors = names.Except(badColors).ToArray();
        KnownColor randomColorName = okColors[randomGen.Next(okColors.Length)];
        randomColor = Color.FromKnownColor(randomColorName);
        if (!ColorsList.Contains(randomColor) && !randomColor.Name.Contains("Light"))
        {
            ColorsList.Add(randomColor);
        }
        else
        {
            GetRandomColor(randomGen);
        }
        return randomColor;
    }
