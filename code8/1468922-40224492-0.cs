    private void RadGridView1_ViewCellFormatting(object sender, CellFormattingEventArgs e)
    {
        if (e.CellElement.ColumnInfo.Name == "V" && e.CellElement is GridSummaryCellElement)
        {
            e.CellElement.Image = Properties.Resources.FilterImage;
        }
        else
        {
            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            e.CellElement.ResetValue(LightVisualElement.TextAlignmentProperty, ValueResetFlags.Local);
            e.CellElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local);
        }
    }
