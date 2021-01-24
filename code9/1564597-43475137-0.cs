    public void ChooseColor()
    {
        ColorDialog ColorDialog = new ColorDialog();
        ColorDialog.ShowDialog();
        System.Drawing.Color Color = ColorDialog.Color;
        return Color;
    }
