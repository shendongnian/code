    SelectColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
    SelectColorComboBox.DrawItem += SelectColorComboBox_DrawItem;
    private void SelectColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        var comboBox = (ComboBox)sender;
        var strColor = (string)comboBox.Items[e.Index];
        var knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), strColor);
        var color = Color.FromKnownColor(knownColor);
        e.DrawBackground();
        e.DrawFocusRectangle();
        using (var brush = new SolidBrush(color))
            e.Graphics.FillRectangle(brush, e.Bounds.X, e.Bounds.Y + 1, 30, e.Bounds.Height - 2);
        TextRenderer.DrawText(e.Graphics, strColor, comboBox.Font, new Point(e.Bounds.X + 30, e.Bounds.Y), color);
    }
