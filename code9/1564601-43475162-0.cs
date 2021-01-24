    public Color ChooseColor()
    {
        ColorDialog ColorDialog = new ColorDialog();
        if(ColorDialog.ShowDialog()==DialogResult.OK)
        {
            return ColorDialog.Color;
        }
        return Color.None;
    }
