    private void RadGridView1_ViewCellFormatting(object sender, CellFormattingEventArgs e)
    {
        if (e.CellElement.ColumnInfo.Name == "V" && e.CellElement is GridSummaryCellElement)
        {
            // adding a new button element
            if (e.CellElement.Children.Count == 0)
            {
                var element = new RadButtonElement();
                element.Margin = new Padding(12, 0, 12, 0);
                element.ImageAlignment = ContentAlignment.MiddleCenter;
                element.Alignment = ContentAlignment.MiddleCenter;
                e.CellElement.Children.Add(element);
            }
    
            // or setting an image to the current element
            //e.CellElement.Image = Properties.Resources.FilterImage;
        }
        else
        {
            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            e.CellElement.ResetValue(LightVisualElement.TextAlignmentProperty, ValueResetFlags.Local);
            e.CellElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local);
        }
    }
