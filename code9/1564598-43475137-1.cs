    public System.Drawing.Color ChooseColor()
    {
        ColorDialog ColorDialog = new ColorDialog();
        ColorDialog.ShowDialog();
        System.Drawing.Color Color = ColorDialog.Color;
        return Color;
    }
