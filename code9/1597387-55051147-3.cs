    public static SolidBrush GetStyleBrush(MetroColorStyle style)
    {
        switch (style)
        {
            case MetroColorStyle.Black:
                return MetroBrushes.Black;
            case MetroColorStyle.White:
                return MetroBrushes.White;
            .
            .
            .
        }
    }
